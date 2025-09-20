using EcomLDC.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities.Orders
{
    public class Order : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Number { get; set; } = default!;     // ex: ORD-2025-0001
        public OrderStatus Status { get; set; } = OrderStatus.Pending; // Pending, Processing, Shipped, Delivered, Cancelled
        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedAtTime { get; set; } = DateTime.Now;
        public DateTime? UpdatedAtTime { get; set; }

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>(); // 34an a3rf al items ely mwgoda fel order da
    }
}
