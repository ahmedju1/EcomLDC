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
    public class CartConfig : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> b)
        {
            b.ToTable("Carts");
            b.HasKey(x => x.id);
            b.HasIndex(x => x.UserId).IsUnique(); // 34an kol user ykon 3ndo cart wa7d bas
            b.Property(x => x.UpdatedAtTime).IsRequired();

            b.HasMany(x => x.Items).WithOne() // 34an a3ml relation ben al cart w al cart items 
             .HasForeignKey(i => i.CartId) // 34an a3ml foreign key fel cart items yshof al cart ely byt3ml 3leh reference
             .OnDelete(DeleteBehavior.Cascade); // 34an lma ams7 al cart yms7 al cart items bta3to kman (cascade delete)
        }
    }
}
