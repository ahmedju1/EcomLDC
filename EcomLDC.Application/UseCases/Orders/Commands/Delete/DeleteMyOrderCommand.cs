using Ecom.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Commands.Delete
{
    public record DeleteMyOrderCommand(Guid UserId, Guid OrderId) : IRequest<Result>; // IRequest hya interface mwgoda fl MediatR library bt3ml define lel request w bt7dd el type bta3 al response ally hayrg3 (hena ana 3ayz a3ml return lel Result)
}
