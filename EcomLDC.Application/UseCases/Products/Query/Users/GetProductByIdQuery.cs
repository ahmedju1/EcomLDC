using Ecom.SharedKernel;
using EcomLDC.Application.UseCases.Products.DtaModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Products.Query.Users
{
    // IRequest hya interface mwgoda fl MediatR library bt3ml define lel request w bt7dd el type bta3 al response ally hayrg3 (hena ana 3ayz a3ml return lel ProductDto)
    public record GetProductByIdQuery(Guid Id) : IRequest<Result<ProductDto>>; 
}
