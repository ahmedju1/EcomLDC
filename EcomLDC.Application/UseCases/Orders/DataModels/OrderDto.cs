using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.DataModels
{
    public class OrderDto(Guid CustomerId , List<OrderItemDto> items)  //decouple Domain from API
   
}
