using EcomLDC.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Persistence.Configurations.Orders
{
    public class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> b)
        {
            b.ToTable("OrderItems");
            b.HasKey(x => x.Id);

            b.Property(x => x.ProductName).IsRequired().HasMaxLength(200);
            b.Property(x => x.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            b.Property(x => x.Quantity).IsRequired();
        }
    }
}
