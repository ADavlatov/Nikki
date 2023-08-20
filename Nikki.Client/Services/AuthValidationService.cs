using Grpc.Net.Client;
using Nikki.Auth;
using Nikki.Client.Interfaces;

namespace Nikki.Client.Services;

public class AuthValidationService
{
    private readonly ILogoutService _logoutService;
    private readonly ITokenService _tokenService;
    private readonly Auth.Auth.AuthClient _authClient;

    public AuthValidationService(ILogoutService logoutService, ITokenService tokenService)
    {
        _logoutService = logoutService;
        _tokenService = tokenService;
        _authClient = new Auth.Auth.AuthClient(GrpcChannel.ForAddress("https://localhost:7269"));
    }

    public bool ValidateUserAuth(HttpRequest request, HttpResponse response)
    {
        string? refreshToken = null;

        if (!request.Cookies.TryGetValue("AccessToken", out var accessToken) &&
            !request.Cookies.TryGetValue("RefreshToken", out refreshToken))
        {
            Logout();
        }

        return accessToken switch
        {
            null when refreshToken is not null => RefreshAndLogout(),
            { } => ValidateAndLogout(),
            _ => Logout()
        };

        bool RefreshAndLogout()
        {
            var refreshResponse = _authClient.GetAccessToken(new AccessTokenRequest { RefreshToken = refreshToken });

            if (!refreshResponse.IsValid)
                return Logout();

            _tokenService.SetTokens(response, refreshResponse.AccessToken, refreshResponse.RefreshToken,
                refreshResponse.UserId);

            return true;
        }

        bool ValidateAndLogout()
        {
            if (_authClient.ValidateToken(new TokenValidationRequest { AccessToken = accessToken }).IsValid)
            {
                return true;
            }

            return Logout();
        }

        bool Logout()
        {
            _logoutService.Logout(response);

            return false;
        }
    }
}