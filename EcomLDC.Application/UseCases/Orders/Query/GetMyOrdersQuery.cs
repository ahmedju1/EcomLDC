using Ecom.SharedKernel;
using EcomLDC.Application.UseCases.Orders.DataModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.Query
{
    public record GetMyOrdersQuery(Guid UserId, int Page = 1, int Size = 10)
        : IRequest<Result<Paged<OrderListItemDto>>>;
}
