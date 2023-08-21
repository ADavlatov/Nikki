using System.IdentityModel.Tokens.Jwt;
using Grpc.Core;
using Nikki.Auth.Models;
using Nikki.Auth.Services.ProtobufMethods;
using Nikki.Auth.Services.Validators;

namespace Nikki.Auth.Services;

public class AuthService : Auth.AuthBase
{
    private readonly UserContext _db = new();

    public override Task<SignInResponse> SignInUser(SignInRequest request, ServerCallContext context)
    {
        return Task.FromResult(new User().SignIn(request, _db));
    }

    public override Task<LogInResponse> LogInUser(LogInRequest request, ServerCallContext context)
    {
        return Task.FromResult(new User().LogIn(request, _db));
    }

    public override Task<TokenValidationResponse> ValidateToken(TokenValidationRequest request,
        ServerCallContext context)
    {
        return Task.FromResult(new Token().Validate(request));
    }

    public override Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Token().Get(request, _db));
    }
}