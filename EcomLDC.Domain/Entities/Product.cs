using EcomLDC.Domain.ValueObjects;
using EcomLDC.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities
{
    // Inhertnace  +  Single Responsibility Principle (SRP) +  LSP → Product can be used anywhere a BaseEntity is expected
    public class Product : BaseEntity 
    {
        public string Name { get;  private set; }
        public Money Price { get;  private set; }   

        private Product() { } // For EF Core

        // Encapsulation + Open/Closed Principle (OCP)
        public Product(string name, Money price) // for creating a new Product
        {
            Name = name;
            Price = price;
        }

    }
}
