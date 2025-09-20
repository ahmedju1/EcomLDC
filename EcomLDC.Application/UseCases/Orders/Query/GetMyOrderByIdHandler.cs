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
    public class GetMyOrderByIdHandler(IOrderRepository repo)
        : IRequestHandler<GetMyOrderByIdQuery, Result<OrderDetailsDto>>
    {
        public async Task<Result<OrderDetailsDto>> Handle(GetMyOrderByIdQuery r, CancellationToken ct)
        {
            var o = await repo.GetDetailsForUserAsync(r.UserId, r.OrderId, ct);
            if (o is null) return Result.Failure<OrderDetailsDto>("Order not found");

            var items = o.Items
                .Select(i => new OrderItemDto(i.ProductName, i.UnitPrice, i.Quantity, i.UnitPrice * i.Quantity))
                .ToList();

            var total = items.Sum(x => x.LineTotal);
            return Result.Success(new OrderDetailsDto(o.id, o.Number, o.CreatedAtTime, o.Status.ToString(), total, items));
        }
    }
}
