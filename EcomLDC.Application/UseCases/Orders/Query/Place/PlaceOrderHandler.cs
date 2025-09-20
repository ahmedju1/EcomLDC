using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Carts;
using EcomLDC.Application.Interfaces.Orders;
using EcomLDC.Application.Interfaces.Products;
using EcomLDC.Application.UseCases.Orders.Commands.Place;
using EcomLDC.Domain.Entities.Orders;
using EcomLDC.Domain.Entities.Products;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Query.Place
{
    public class PlaceOrderHandler(
     ICartRepository carts,
     IProductRepository products,
     IOrderRepository _orderRepo,
     IUnitOfWork uow
 ) : IRequestHandler<PlaceOrderCommand, Result<Guid>>
    {
        public async Task<Result<Guid>> Handle(PlaceOrderCommand r, CancellationToken ct)
        {
            // 1- byshof en el cart msh fady
            var cart = await carts.GetForUserAsync(r.UserId, ct); // GetForUserAsync hya method mwgoda fl ICartRepository btgeb el cart bta3 el user ely 3ayzo
            if (cart is null || cart.Items.Count == 0)
                return Result.Failure<Guid>("Cart is empty"); // Empty Cart 

            // 2- byshof en el products mwgoda w fe stock kfaya
            var prods = await products.GetByIdsAsync(cart.Items.Select(i => i.ProductId).Distinct(), ct); // GetByIdsAsync hya method mwgoda fl IProductRepository btgeb el products b id mo3ayana
            var prodsDict = prods.ToDictionary(p => p.id, p => p); // 34an a3ml dictionary 3la 7sb el id 34an a3ml lookup bsr3a 3ala el products b id
            var outOfStockNames = new List<string>(); // list 34an a7ot feha asma el products ely ma3ndhash stock kfaya

            foreach (var i in cart.Items) // loop 3la kol el items fl cart w at2kd en el product mwgod w fe stock kfaya
            {
                if (!prodsDict.TryGetValue(i.ProductId, out var p) || p.IsDeleted || p.StockQty < i.Quantity) // TryGetValue hya method mwgoda fl dictionary btgeb el value b id mo3ayan w lw ma l2tsh byrg3 false
                    outOfStockNames.Add(i.ProductName); // lw el product msh mwgod aw etms7 aw ma3ndhash stock kfaya a7ot esm el product fl list
            }
            if (outOfStockNames.Count > 0)
                return Result.Failure<Guid>($"Out of stock: {string.Join(", ", outOfStockNames)}"); // Return failure w a3ml join lel asma el products ely ma3ndhash stock kfaya

            // 3- by3ml order w by7ot feh el items mn el cart 
            var order = new Order
            {
                UserId = r.UserId,
                Number = $"ORD-{DateTime.UtcNow:yyyyMMddHHmmss}-{Guid.NewGuid().ToString()[..6]}", // Generate unique order number 
                Status = OrderStatus.Pending
            };
            //w by7seb el total w by5sm el stock mn el products ely fel order w byms7 el cart ba3d kda
            decimal total = 0m;
            foreach (var i in cart.Items)
            {
                var p = prodsDict[i.ProductId];
                order.Items.Add(new OrderItem
                {
                    OrderId = order.id,
                    ProductId = p.id,
                    ProductName = i.ProductName,
                    UnitPrice = i.PriceAtAdd, // PriceAtAdd hya el price ely kan 3ndy lma 7atet el item fl cart
                    Quantity = i.Quantity
                });
                total += i.PriceAtAdd * i.Quantity;

                // 4- by5sm el stock
                p.StockQty -= i.Quantity;
            }


            // 5- by7ot el order fl database w byms7 el cart
            await _orderRepo.AddAsync(order, ct); // AddAsync hya method mwgoda fl IOrderRepository bt3ml add lel entity fel database
            await carts.ClearAsync(cart.id, ct); // ClearAsync hya method mwgoda fl ICartRepository btms7 kol el items fl cart
            await uow.SaveChangesAsync(ct); 

            // 6 - email


            // 7- return order id 
            return Result.Success(order.id);

        }
    }
}
