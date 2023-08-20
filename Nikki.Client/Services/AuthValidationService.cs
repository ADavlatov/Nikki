using Grpc.Net.Client;
using Nikki.Auth;

namespace Nikki.Client.Services;

public class AuthValidationService
{
    public bool ValidateUserAuth(HttpRequest request, HttpResponse response)
    {
        var client = new Auth.Auth.AuthClient(GrpcChannel.ForAddress("https://localhost:7269"));
        string? refreshToken = null;

        if (!request.Cookies.TryGetValue("AccessToken", out var accessToken) &&
            !request.Cookies.TryGetValue("RefreshToken", out refreshToken))
        {
            new LogoutService().Logout(response);

            return false;
        }

        switch (accessToken)
        {
            case null when refreshToken is not null:
                var refreshResponse = client.GetAccessToken(new AccessTokenRequest { RefreshToken = refreshToken });

                if (refreshResponse.IsValid)
                {
                    new TokenService().SetTokens(response, refreshResponse.AccessToken, refreshResponse.RefreshToken,
                        refreshResponse.UserId);

                    return true;
                }

                new LogoutService().Logout(response);

                return false;
            case not null when refreshToken is null:
                new LogoutService().Logout(response);

                return false;
            case not null:
                if (client.ValidateToken(new TokenValidationRequest { AccessToken = accessToken }).IsValid)
                {
                    return true;
                }

                return false;
        }

        new LogoutService().Logout(response);

        return false;
    }
}