using EcomLDC.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Persistence.Configurations
{
    public class OrderConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> b)
        {
            b.ToTable("Users");

            b.HasKey(x => x.id); // Primary Key

            b.Property(x => x.Username)
                .IsRequired()
                .HasMaxLength(50); // Unique constraint

            b.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(200); 

            b.Property(x => x.PasswordHash)
                .IsRequired();

            b.Property(x => x.Role).IsRequired();
            b.Property(x => x.IsDeleted).HasDefaultValue(false);

            //btnmn3 tkrar al user a2t registration
            b.HasIndex(x => x.Username).IsUnique(); // Unique constraint ya3ny mafish user y2dr ykoon 3ndo nafs al username
            b.HasIndex(x => x.Email).IsUnique(); // Unique constraint ya3ny mafish user y2dr ykoon 3ndo nafs al email
        }
    }
}
