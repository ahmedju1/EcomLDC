using EcomLDC.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.DTOs
{
    public record ProductDto(Guid id,string Name ,decimal price);//decouple Domain from API
    
}
