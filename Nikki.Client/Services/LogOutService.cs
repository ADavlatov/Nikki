namespace Nikki.Client.Services;

public static class LogOutService
{
    public static void LogOut(HttpResponse response)
    {
        response.Cookies.Delete("AccessToken");
        response.Cookies.Delete("RefreshToken");
    }
}