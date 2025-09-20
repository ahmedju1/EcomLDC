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
    public class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> b)
        {
            b.ToTable("Orders");
            b.HasKey(x => x.id);

            b.Property(x => x.Number).IsRequired().HasMaxLength(32);
            b.HasIndex(x => x.Number).IsUnique(); // 34an ma ykonsh fe orders b nafs el number fl database

            b.Property(x => x.Status).IsRequired();
            b.Property(x => x.IsDeleted).HasDefaultValue(false);
            // 34an a3ml relation ben el orders w el order items
            b.HasMany(x => x.Items).WithOne() //b.hasMany 3la 7sb en el order feh kaza order item w el order item bytl3 mn order wa7d bs 
                .HasForeignKey(i => i.OrderId)  // w b3ml foreign key 3la orderId fl order item 34an a3ml relation benhom
             .OnDelete(DeleteBehavior.Cascade); // lw 7adt order etms7 kol el order items ely mwgoda feh hatetms7 kman

            b.HasIndex(x => new { x.UserId, x.IsDeleted }); // 34an a3ml index 3la userId w isDeleted 34an a3ml query 3la kol el orders bta3t user mo3ayan w a3ml filter 3la el deleted orders
        }
    }
}
