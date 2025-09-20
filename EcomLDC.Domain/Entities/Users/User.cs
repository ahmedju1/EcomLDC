using EcomLDC.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Domain.Entities.Users
{
    public class User : BaseEntity
    {
       
        public string Username { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public UserRole Role { get; set; } = UserRole.Customer;

        public DateTime CreatedAtTime { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAtTime { get; set; }

        // Soft-delete flag
        public bool IsDeleted { get; set; } = false;

    }
}
