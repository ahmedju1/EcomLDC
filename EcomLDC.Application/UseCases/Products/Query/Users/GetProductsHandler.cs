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
    public class GetProductsHandler(IProductRepository repo)
       : IRequestHandler<GetProductsQuery, Result<Paged<ProductListItemDto>>>
    {
        // Handle hya method mwgoda fl IRequestHandler interface btetnady lma yb2a fe request mn no3 GetProductsQuery
        public async Task<Result<Paged<ProductListItemDto>>> Handle(GetProductsQuery r, CancellationToken ct) 
        {
            var (items, total) = await repo.GetPagedAsync(r.Page, r.Size, r.IncludeOutOfStock, ct); // GetPagedAsync hya method btrg3li list mn el products b pagination
            // b3ml map lel items ely reg3tliha mn el database 3la 7sb el ProductListItemDto (de bta5od shwaya min el properties mn el Product entity w bt3mlhom dto 34an ab3thom lel client)
            var mapped = items.Select(p => new ProductListItemDto(p.id, p.Name, p.Price, p.StockQty)).ToList();
            return Result.Success(new Paged<ProductListItemDto>(mapped, total, r.Page, r.Size)); // b3ml return lel paged list of ProductListItemDto 
        }
    }
}
