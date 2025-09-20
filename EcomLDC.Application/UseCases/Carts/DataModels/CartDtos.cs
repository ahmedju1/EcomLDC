using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.DataModels
{
    public record CartDto(
        IReadOnlyList<CartItemDto> Items,
        decimal Subtotal,
        decimal Tax,
        decimal Fees,
        decimal Total,
        bool IsEmpty
    ); 
}
