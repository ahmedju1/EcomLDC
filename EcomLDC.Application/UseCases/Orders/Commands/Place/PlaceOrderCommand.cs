using Ecom.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Commands.Place
{
    public record PlaceOrderCommand(Guid UserId) : IRequest<Result<Guid>>; // yrag3 ID bta3 el order el gdida
}
