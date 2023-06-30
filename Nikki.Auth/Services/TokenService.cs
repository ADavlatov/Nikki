using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Nikki.Auth.Services;

public class TokenService
{
    // Генерация JWT токена
    public static JwtSecurityToken GetJwtToken(string username, int lifetime)
    {
        return new(issuer: AuthOptions.Issuer,
            audience: AuthOptions.Audience,
            claims: GetClaims(username)
                .Claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(lifetime)),
            signingCredentials: new(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    }

    //Получение claims для генерации JWT токена
    private static ClaimsIdentity GetClaims(string usernameOrEmail)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, usernameOrEmail)
        };
        
        ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

        return claimsIdentity;
    }

    private class AuthOptions
    {
        public const string Issuer = "Nikki.Auth";

        public const string Audience = "Nikki.Client";

        const string Key = "mysupersecret_secretkey!123";

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
    }
}