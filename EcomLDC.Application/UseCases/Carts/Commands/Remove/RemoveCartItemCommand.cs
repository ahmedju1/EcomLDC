using Ecom.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Remove
{
    public record RemoveCartItemCommand(Guid UserId, Guid ItemId) : IRequest<Result>;
}
