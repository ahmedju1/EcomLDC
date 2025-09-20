using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Orders;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Commands.Delete
{
    public class DeleteMyOrderHandler(IOrderRepository repo, IUnitOfWork uow)
        : IRequestHandler<DeleteMyOrderCommand, Result>
    {
        public async Task<Result> Handle(DeleteMyOrderCommand r, CancellationToken ct)
        {
            var ok = await repo.SoftDeleteAsync(r.UserId, r.OrderId, ct);
            if (!ok) return Result.Failure("Order not found");
            await uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }
}
