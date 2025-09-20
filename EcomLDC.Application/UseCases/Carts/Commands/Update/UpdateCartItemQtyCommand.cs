using Ecom.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Update
{
    public record UpdateCartItemQtyCommand(Guid UserId, Guid ItemId, int Quantity) : IRequest<Result>;

}
