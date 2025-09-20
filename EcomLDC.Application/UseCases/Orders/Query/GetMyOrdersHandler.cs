using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces.Orders;
using EcomLDC.Application.UseCases.Orders.DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Query
{
    public class GetMyOrdersHandler(IOrderRepository repo)
       : IRequestHandler<GetMyOrdersQuery, Result<Paged<OrderListItemDto>>>
    {
        public async Task<Result<Paged<OrderListItemDto>>> Handle(GetMyOrdersQuery r, CancellationToken ct)
        {
            var (orders, total) = await repo.GetPagedForUserAsync(r.UserId, r.Page, r.Size, ct); // GetPagedForUserAsync hya method btrg3li list mn el orders b pagination 34an al user ely 3ayz yshof orders bta3to bs

            var list = orders.Select(o =>
            {
                var totalAmount = o.Items.Sum(i => i.UnitPrice * i.Quantity); // 34an a7seb al total amount bta3 al order 3la asas el items ely mwgoda feh (al item byeb2a fih unit price w quantity)
                return new OrderListItemDto(o.id, o.Number, o.CreatedAtTime, o.Status.ToString(), totalAmount);
            }).ToList();

            return Result.Success(new Paged<OrderListItemDto>(list, total, r.Page, r.Size));
        }
    }
}
