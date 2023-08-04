using Grpc.Net.Client;

namespace Nikki.Client.Services;

public class AuthValidationService
{
    public bool ValidateUserAuth(HttpRequest request, HttpResponse response)
    {
        var client = new Auth.AuthClient(GrpcChannel.ForAddress(""));
        string? accessToken;
        
        if (!request.Cookies.TryGetValue("AccessToken", out accessToken))
        {
            return false;
        }
        
        var tokenValidationResponse = client.ValidateToken(new TokenValidationRequest { AccessToken = accessToken});

        if (tokenValidationResponse.IsValid)
        {
            return true;
        }

        string? refreshToken;
        
        if (!request.Cookies.TryGetValue("RefreshToken", out refreshToken))
        {
            return false;
        }
        
        var accessTokenResponse = client.GetAccessToken(new AccessTokenRequest { RefreshToken = refreshToken});

        if (accessTokenResponse.IsValid)
        {
            new TokenService().SetTokens(response, accessTokenResponse.AccessToken, accessTokenResponse.RefreshToken);
            new AuthValidationService().ValidateUserAuth(request, response);
        }

        return false;
    }
}