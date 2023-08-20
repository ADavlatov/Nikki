using Nikki.Client.Interfaces;

namespace Nikki.Client.Services;

public class LogoutService : ILogoutService
{
    public void Logout(HttpResponse response)
    {
        response.Cookies.Delete("AccessToken");
        response.Cookies.Delete("RefreshToken");
        response.Cookies.Delete("UserId");
    }
}