using EcomLDC.Domain.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Persistence.Configurations.Products
{
    public class ProductConfig : IEntityTypeConfiguration<Product> //mst5id IEntityTypeConfiguration l2nash2 configuration lel entity bta3ty fl database 
    {
        public void Configure(EntityTypeBuilder<Product> b)
        {
            b.ToTable("Products");
            b.HasKey(x => x.id);

            b.Property(x => x.Name).IsRequired().HasMaxLength(200);
            b.HasIndex(x => x.Name).IsUnique(); // 34an ma ykonsh fe products b nafs el esm fl database 

            b.Property(x => x.Price).IsRequired().HasColumnType("decimal(18,2)");
            b.Property(x => x.StockQty).IsRequired(); // 3dd al montgat ely mwgoda fl stock

            b.Property(x => x.IsDeleted).HasDefaultValue(false); // Soft delete
        }
    }
}
