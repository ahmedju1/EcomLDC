using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces.Carts;
using EcomLDC.Application.UseCases.Carts.DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Query
{
    public class GetMyCartHandler(ICartRepository repo)
        : IRequestHandler<GetMyCartQuery, Result<CartDto>>
    {
        public async Task<Result<CartDto>> Handle(GetMyCartQuery r, CancellationToken ct)
        {
            var cart = await repo.GetForUserAsync(r.UserId, ct); // bgeb el cart bta3 el user lw mwgod

            var items = (cart?.Items ?? []).Select(i =>  // lw ma kansh fe cart aw ma kansh feh items arga3 list fadiya
                new CartItemDto(i.Id, i.ProductId, i.ProductName, i.PriceAtAdd, i.Quantity, i.PriceAtAdd * i.Quantity) // b3ml map lel cart item 34an a3ml return lel dto
            ).ToList();

            var subtotal = items.Sum(x => x.Subtotal); // el subtotal howa magmou3 el prices bta3t kol el items
            decimal tax = 0m;  //0m = 0.0 fl decimal  
            decimal fees = 0m;  
            var total = subtotal + tax + fees;

            var dto = new CartDto(items, subtotal, tax, fees, total, items.Count == 0);
            return Result.Success(dto);
        }
    }

}
