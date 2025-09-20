using EcomLDC.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.Interfaces.Users
{
    public interface IUserRepository
    {
        Task<bool> ExistsByUsernameAsync(string username, CancellationToken ct = default); // 34an at2kd en al username msh mwgod abl ma a3ml registration
        Task<bool> ExistsByEmailAsync(string email, CancellationToken ct = default); // 34an at2kd en al email msh mwgod abl ma a3ml registration
        Task AddAsync(User user, CancellationToken ct = default); // 34an a3ml add lel user al gdyd
        Task<User?> GetByUsernameAsync(string username, CancellationToken ct = default); // 34an agib al user 3la asas al username bta3o (lma y3ml login)
    }
}
