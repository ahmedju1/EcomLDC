using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities.Carts
{
    public class CartItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid CartId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; } = default!; // snapshot of product name
        public decimal PriceAtAdd { get; set; } // snapshot of product price at the time of adding to cart
        public int Quantity { get; set; } // >=1
    }
}
