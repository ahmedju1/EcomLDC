using EcomLDC.Application.Security;
using EcomLDC.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;

namespace EcomLDC.Infrastructure.Security
{
    public class JwtTokenService(IConfiguration config) : IJwtTokenService //IJwtTokenService hya interface 3shan a3ml implementation lha hna w fydtha hya anha a3ml create lel token
    {
        public string Create(User user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)); // config["Jwt:Key"] hya el key ely ana 3ayzo ast5dmoh fl token w hwa mwgod fl appsettings.json
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256); // HmacSha256 hya algorithm ely ana 3ayzo ast5dmoh fl token

            var claims = new[] // claims hya el ma3lomat ely hatkon mwgoda fl token
            {
            new Claim(Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames.Sub, user.id.ToString()), // sub hya el id bta3 al user
            new Claim(ClaimTypes.Name, user.Username), // Name hya el username bta3 al user
            new Claim(ClaimTypes.Role, user.Role.ToString()), // Role hya el role bta3 al user (Admin, User)
        };

            var jwt = new JwtSecurityToken( // JwtSecurityToken hya class mwgoda fl Microsoft.IdentityModel.Tokens btst5dm 3shan a3ml token
                issuer: config["Jwt:Issuer"], // config["Jwt:Issuer"] hya el issuer ely ana 3ayzo ast5dmoh fl token w hwa mwgod fl appsettings.json
                audience: config["Jwt:Audience"], // config["Jwt:Audience"] hya el audience ely ana 3ayzo ast5dmoh fl token w hwa mwgod fl appsettings.json
                claims: claims, // el claims ely ana 3ayzo ast5dmoh fl token
                expires: DateTime.UtcNow.AddHours(6), // expires hya el wa2t ely hatnfa3 feh el token (hna 6 sa3at)
                signingCredentials: creds); // el signingCredentials ely ana 3ayzo ast5dmoh fl token

            return new JwtSecurityTokenHandler().WriteToken(jwt); // JwtSecurityTokenHandler hya class mwgoda fl Microsoft.IdentityModel.Tokens btst5dm 3shan a3ml write lel token w btrg3o string 34an a3ml b3tho lel user
        }
    }
}
