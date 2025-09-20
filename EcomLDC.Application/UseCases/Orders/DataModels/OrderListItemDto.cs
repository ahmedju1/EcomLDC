using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.DataModels
{
    public record OrderListItemDto(Guid Id, string Number, DateTime DateTime, string Status, decimal TotalAmount);

}
