using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Orders.DataModels
{
    public record Paged<T>(IReadOnlyList<T> Items, int Total, int Page, int Size); // generic record 34an a3ml return lel paged results ay 7aga(products, users, etc.)

}
