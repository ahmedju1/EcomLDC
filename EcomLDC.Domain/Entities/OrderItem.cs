using EcomLDC.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid ProductId { get;  set; } // Encapsulation
        public int Quantity { get;  set; } // Encapsulation
        public ValueObjects.Money Price { get;  set; } // Encapsulation

        //private OrderItem() { } // For EF Core
        
        //public OrderItem(Guid productId, int quantity, ValueObjects.Money price) // for creating a new OrderItem
        //{
        //    if (productId == Guid.Empty)
        //        throw new ArgumentException("ProductId cannot be empty");
        //    if (quantity <= 0)
        //        throw new ArgumentException("Quantity must be greater than 0");
        //    if (price.Amount <= 0)
        //        throw new ArgumentException("Price must be greater than 0");
        //    ProductId = productId;
        //    Quantity = quantity;
        //    Price = price;
        //}
        //public void UpdateQuantity(int newQuantity)
        //{
        //    if (newQuantity <= 0)
        //        throw new ArgumentException("Quantity must be greater than 0");

        //    Quantity = newQuantity;
        //}

 
        //public Money GetTotal()
        //{
        //    return new Money(Price.Amount * Quantity, Price.Currency);
        //}

    }
}
