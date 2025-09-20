using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Carts;
using EcomLDC.Application.Interfaces.Products;
using EcomLDC.Domain.Entities.Carts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Add
{
    public class AddCartItemHandler(
        ICartRepository carts,
        IProductRepository products,
        IUnitOfWork uow) : IRequestHandler<AddCartItemCommand, Result>
    {
        public async Task<Result> Handle(AddCartItemCommand r, CancellationToken ct)
        {
            // at722 min el userId w el productId w el quantity
            var product = await products.GetByIdAsync(r.ProductId, includeDeleted: false, ct); // at722 min el productId
            if (product is null) return Result.Failure("Product not found"); // lazim product ykwn mwgod w msh deleted

          
            if (product.StockQty <= 0)
                return Result.Failure("Product is out of stock");

            // at722 min el cart bta3 el userId w lw msh mwgod a3ml wa7d gdida
            var cart = await carts.EnsureForUserAsync(r.UserId, ct);

            // at722 min el cart item lw mwgod 34an a3ml update lel quantity
            var existing = await carts.GetItemForUserAsync(r.UserId, r.ProductId, ct);
            if (existing is not null)
            {
                var newQty = existing.Quantity + r.Quantity;
                if (newQty > product.StockQty)
                    return Result.Failure($"Only {product.StockQty} left in stock"); // lw el new quantity akbar mn el stockQty ely mwgod arga3 error

                existing.Quantity = newQty;
            }
            else // law msh mwgod el item fel cart
            {
                // new item 34an a3ml add lel item fel cart
                if (r.Quantity > product.StockQty)
                    return Result.Failure($"Only {product.StockQty} left in stock");

                await carts.AddItemAsync(cart.id, new CartItem
                {
                    CartId = cart.id,
                    ProductId = product.id,
                    ProductName = product.Name,   // snapshot
                    PriceAtAdd = product.Price,   // snapshot
                    Quantity = r.Quantity
                }, ct);
            }

            // b3ml save lel changes
            await uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }
}
