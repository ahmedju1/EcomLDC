using EcomLDC.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities.Products
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = default!;
        public string? Description { get; set; }
        public decimal Price { get; set; }          
        public int StockQty { get; set; }    // 3dd al montgat ely mwgoda fl stock        
        public bool IsDeleted { get; set; } = false; // Soft delete

        public DateTime CreatedAtTime { get; set; } = DateTime.Now; //34an a3rf emta et3ml create lel product
        public DateTime? UpdatedAtTime { get; set; } //34an a3rf emta et3ml update lel product
    }
}
