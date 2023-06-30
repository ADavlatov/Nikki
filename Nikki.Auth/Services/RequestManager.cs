using System.IdentityModel.Tokens.Jwt;
using Nikki.Auth.Models;

namespace Nikki.Auth.Services;

public class RequestManager
{
    public static string? ValidateSignInRequest(UserContext db, SignInRequest request)
    {
        User? user = db.Users.FirstOrDefault(x =>
            (x.Username == request.Username || x.Email == request.Username) && x.Password == request.Password);

        if (user == null)
        {
            return "Неверный логин или пароль";
        }

        return null;
    }
    
    public static string? ValidateLogInRequest(UserContext db, LogInRequest request)
    {
        User? user = db.Users.FirstOrDefault(x =>
            (x.Username == request.Username || x.Email == request.Username) && x.Password == request.Password);
        return null;
    }
    
    public static string? ValidateToken(UserContext db, string token)
    {
        JwtSecurityToken jwt = new JwtSecurityToken(token);

        if (db.Users.FirstOrDefault(x => x.Username == jwt.Claims.First().Value) == null)
        {
            return "Неверный access token";
        }

        return null;
    }
}