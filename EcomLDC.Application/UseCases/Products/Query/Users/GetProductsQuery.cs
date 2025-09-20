using Ecom.SharedKernel;
using EcomLDC.Application.UseCases.Products.DtaModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Products.Query.Users
{// record hya keyword fl C# bt3ml define lel class bas btkon immutable by default (ya3ni msh 2dr a3ml change 3la al properties bta3tha ba3d ma a3ml create lel object) w btkon by default byml implement lel IEquatable interface 34an a2dr akarn ben objects bta3tha b easily w kda
    public record GetProductsQuery(int Page = 1, int Size = 12, bool IncludeOutOfStock = true)  
        : IRequest<Result<Paged<ProductListItemDto>>>; // IRequest hya interface mwgoda fl MediatR library bt3ml define lel request w bt7dd el type bta3 al response ally hayrg3 (hena ana 3ayz a3ml return lel paged list of ProductListItemDto)
}
