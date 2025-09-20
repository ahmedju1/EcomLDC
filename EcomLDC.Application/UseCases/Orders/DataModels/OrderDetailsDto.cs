using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.DataModels
{
    public record OrderDetailsDto(Guid Id, string Number, DateTime Dateime, string Status, decimal TotalAmount, IReadOnlyList<OrderItemDto> Items);

}
