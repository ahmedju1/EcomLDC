using Ecom.SharedKernel;
using EcomLDC.Domain.Entities.Products;
using EcomLDC.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.UseCases.Products.DtaModels
{
// generic record 34an a3ml return lel paged results ay 7aga(products, users, etc.)

    public record Paged<T>(IReadOnlyList<T> Items, int Total, int Page, int Size); 
}
