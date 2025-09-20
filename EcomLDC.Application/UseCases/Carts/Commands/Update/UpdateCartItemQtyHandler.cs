using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces;
using EcomLDC.Application.Interfaces.Carts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Update
{
    public class UpdateCartItemQtyHandler(ICartRepository repo, IUnitOfWork uow)
      : IRequestHandler<UpdateCartItemQtyCommand, Result>
    {
        public async Task<Result> Handle(UpdateCartItemQtyCommand r, CancellationToken ct)
        {
            bool ok = r.Quantity == 0 // lw el quantity 0 y3ny 7b2a ams7 el item mn el cart
                ? await repo.RemoveItemAsync(r.UserId, r.ItemId, ct)
                : await repo.UpdateQtyAsync(r.UserId, r.ItemId, r.Quantity, ct);

            if (!ok) return Result.Failure("Cart item not found");

            await uow.SaveChangesAsync(ct);
            return Result.Success();
        }
    }

}
