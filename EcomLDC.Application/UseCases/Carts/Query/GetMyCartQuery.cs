using Ecom.SharedKernel;
using EcomLDC.Application.UseCases.Carts.DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.Query
{
    public record GetMyCartQuery(Guid UserId) : IRequest<Result<CartDto>>;
}
