namespace Nikki.Client.Interfaces;

public interface ITokenService
{
    public void SetTokens(HttpResponse response, string accessToken, string refreshToken, string userId);
}