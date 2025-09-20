using Ecom.SharedKernel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Commands.Add
{
    public record AddCartItemCommand(Guid UserId, Guid ProductId, int Quantity) : IRequest<Result>;

}
