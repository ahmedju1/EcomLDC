using EcomLDC.Domain.Entities.Users;
using System.Security.Claims;

namespace EcomLDC.Api.Auth
{
    public static class UserClaimsExtensions
    {
        public static bool TryGetUserId(this ClaimsPrincipal user, out Guid userId)
        {
          
            var sub = user.FindFirstValue(ClaimTypes.NameIdentifier) ?? user.FindFirstValue("sub"); // "sub" hya el claim ely ana 3ayzo ast5dmoh fl token w hwa mwgod fl JwtTokenService
            return Guid.TryParse(sub, out userId);
        }


        public static Guid GetUserIdOrThrow(this ClaimsPrincipal user)
            => TryGetUserId(user, out var id) ? id
               : throw new UnauthorizedAccessException("UserId claim is missing or invalid.");
    }
}
