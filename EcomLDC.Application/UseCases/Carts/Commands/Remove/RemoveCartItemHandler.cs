using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Carts;
using EcomLDC.Application.UseCases.Carts.Commands.Update;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Remove
{
    public class RemoveCartItemHandler(ICartRepository repo, IUnitOfWork uow)
        : IRequestHandler<RemoveCartItemCommand, Result>
    {
        public async Task<Result> Handle(RemoveCartItemCommand r, CancellationToken ct)
        {
            var ok = await repo.RemoveItemAsync(r.UserId, r.ItemId, ct);
            if (!ok) return Result.Failure("Cart item not found");
            await uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }
}
