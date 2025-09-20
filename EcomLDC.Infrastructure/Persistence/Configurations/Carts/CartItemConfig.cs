using EcomLDC.Domain.Entities.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Persistence.Configurations.Carts
{
    public class CartItemConfig : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> b)
        {
            b.ToTable("CartItems");
            b.HasKey(x => x.Id);

            b.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
            b.Property(x => x.PriceAtAdd).HasColumnType("decimal(18,2)").IsRequired();
            b.Property(x => x.Quantity).IsRequired();
        }
    }
}
