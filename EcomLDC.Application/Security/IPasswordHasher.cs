using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomLDC.Application.Security
{
    public interface IPasswordHasher
    {
        string Hash(string password); // Hashing lil password 2abl ma storing it in the database
        bool Verify(string password, string hash); // Verification lil password wa2t login
    } 
}
