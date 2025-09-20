using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.DataModels
{
    public record OrderItemDto(string ProductName, decimal UnitPrice, int Quantity, decimal LineTotal); // LineTotal hya el total bta3 el item dah (UnitPrice * Quantity)

}
