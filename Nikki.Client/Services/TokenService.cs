using Nikki.Client.Interfaces;

namespace Nikki.Client.Services;

public class TokenService : ITokenService
{
    public void SetTokens(HttpResponse response, string accessToken, string refreshToken, string userId)
    {
        response.Cookies.Delete("AccessToken");
        response.Cookies.Delete("RefreshToken");
        response.Cookies.Delete("UserId");
        response.Cookies.Append("AccessToken", accessToken, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1)});
        response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(180)});
        response.Cookies.Append("UserId", userId, new CookieOptions { Expires = DateTimeOffset.Now.AddDays(1)});
    }
}