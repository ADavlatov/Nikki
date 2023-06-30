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
}