using Ecom.SharedKernel;
using EcomLDC.Application.Interfaces.Products;
using EcomLDC.Application.UseCases.Products.DtaModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Products.Query.Users
{
    // constructor injection l repository 34an ast5dmha fl handler (Primary Constructor for classes )
    public class GetProductByIdHandler(IProductRepository repo)
        // IRequestHandler hya interface mwgoda fl MediatR library bt3ml define lel handler w bt7dd el type bta3 al request w al response 
        : IRequestHandler<GetProductByIdQuery, Result<ProductDto>> //(hena al request no3 GetProductByIdQuery w al response no3 Result<ProductDto>)
    {
        // Handle hya method mwgoda fl IRequestHandler interface btetnady lma yb2a fe request mn no3 GetProductByIdQuery
        public async Task<Result<ProductDto>> Handle(GetProductByIdQuery r, CancellationToken ct) 
        {
            var p = await repo.GetByIdAsync(r.Id, includeDeleted: false, ct); // GetByIdAsync hya method btrg3li product 3la asas al id bta3o 
            if (p is null) return Result.Failure<ProductDto>("Product not found");
            return Result.Success(new ProductDto(p.id, p.Name, p.Description, p.Price, p.StockQty, p.IsDeleted));
        }
    }
}
