using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Carts.DataModels
{
    public record CartItemDto(
        Guid ItemId,
        Guid ProductId,
        string ProductName,
        decimal Price,
        int Quantity,
        decimal Subtotal
    ); 
}
