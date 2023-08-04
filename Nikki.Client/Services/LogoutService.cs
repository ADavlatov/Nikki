namespace Nikki.Client.Services;

public static class LogoutService
{
    public static void Logout(HttpResponse response)
    {
        response.Cookies.Delete("AccessToken");
        response.Cookies.Delete("RefreshToken");
    }
}