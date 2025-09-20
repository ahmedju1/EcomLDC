using EcomLDC.Application.Interfaces.Users;
using EcomLDC.Domain.Entities.Users;
using EcomLDC.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Infrastructure.Repositories.Users
{
    public class UserRepository(EcomLDCDbContext db) : IUserRepository
    {
        public async Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct = default) // 34an at2kd en al username msh mwgod abl ma a3ml registration
            => await db.Users.AnyAsync(u => u.Username == username, ct);  // AnyAsync hya method mwgoda fl Entity Framework bt2kd en fe ay record mwgod fl database byshbah al condition ally ana 3ayzo

        public async Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default) // 34an at2kd en al email msh mwgod abl ma a3ml registration
            => await db.Users.AnyAsync(u => u.Email == email, ct); 

        public async Task AddAsync(User user, CancellationToken ct = default) // 34an a3ml add lel user al gdyd
            => await db.Users.AddAsync(user, ct); // AddAsync hya method mwgoda fl Entity Framework bt3ml add lel entity fel database

        public Task<User?> GetByUsernameAsync(string username, CancellationToken ct = default) // 34an agib al user 3la asas al username bta3o (lma y3ml login)
            => db.Users.FirstOrDefaultAsync(u => u.Username == username, ct); // FirstOrDefaultAsync hya method mwgoda fl Entity Framework btgeb awl record byshbah al condition ally ana 3ayzo w lw ma l2tsh byrg3 null
    }
}
