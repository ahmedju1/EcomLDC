using EcomLDC.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities.Carts
{
    public class Cart : BaseEntity
    {
        public Guid UserId { get; set; }
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();
        public DateTime UpdatedAtTime { get; set; } = DateTime.Now;
    }
}
