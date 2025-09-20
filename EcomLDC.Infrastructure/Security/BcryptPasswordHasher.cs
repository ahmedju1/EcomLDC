using EcomLDC.Application.Security;


namespace EcomLDC.Infrastructure.Security
{
    public class BcryptPasswordHasher : IPasswordHasher
    {
        public string Hash(string password) => BCrypt.Net.BCrypt.HashPassword(password); // Hashing lil password 2abl ma storing it in the database
        public bool Verify(string password, string hash) => BCrypt.Net.BCrypt.Verify(password, hash); // Verification lil password wa2t login
    }
}
