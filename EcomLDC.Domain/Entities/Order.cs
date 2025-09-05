using EcomLDC.Domain.ValueObjects;
using EcomLDC.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities
{
    public class Order : BaseEntity
    {
        private readonly List<OrderItem> _orderItems = new(); // Encapsulation
        public IReadOnlyCollection<OrderItem> OrderItems => _orderItems.AsReadOnly(); // Encapsulation
        public Guid CustomerId { get; private set; } // Encapsulation

        private Order() { } // For EF Core
       public Order(Guid customerId) // for creating a new Order
        {
            if (customerId == Guid.Empty)             
                throw new ArgumentException("CustomerId cannot be empty");
            CustomerId = customerId;
        }
        public void AddItem(Guid productId, int quantity, Money price)   
        {
            if (quantity <= 0)                          
                throw new ArgumentException("Quantity must be greater than 0");

            _orderItems.Add(new OrderItem(productId, quantity, price));   
        }
    }
}
