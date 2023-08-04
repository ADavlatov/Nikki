namespace Nikki.Client.Services;

public class TokenService
{
    public void SetTokens(HttpResponse response, string accessToken, string refreshToken)
    {
        response.Cookies.Delete("AccessToken");
        response.Cookies.Delete("RefreshToken");
        response.Cookies.Append("AccessToken", accessToken);
        response.Cookies.Append("RefreshToken", refreshToken);
    }
}