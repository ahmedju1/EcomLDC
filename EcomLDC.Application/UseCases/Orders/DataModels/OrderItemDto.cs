using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.DataModels
{
    //one product in the order
    public class OrderItemDto(Guid ProductId , int Quantity); //decouple Domain from API
   
}
