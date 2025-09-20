using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Products.DtaModels
{
    // lw 7bt a3ml return lel product details 3la asas al id bta3o f msh 3ayz a3ml return lel product entity directly 34an a7afz 3la encapsulation w msh a3ml expose lel entity details fl application layer bshkl direct
    public record ProductDto(Guid Id, string Name, string? Description, decimal Price, int StockQty, bool IsDeleted); 
}
