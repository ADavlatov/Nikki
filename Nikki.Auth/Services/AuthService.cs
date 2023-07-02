using System.IdentityModel.Tokens.Jwt;
using Grpc.Core;
using Nikki.Auth.Models;
using Nikki.Auth.Services.Validators;

namespace Nikki.Auth.Services;

public class AuthService : Auth.AuthBase
{
    private readonly UserContext _db = new();

    public override Task<SignInResponse> SignInUser(SignInRequest request, ServerCallContext context)
    {
        SignInValidator signInValidator = new SignInValidator();
        var validateResult = signInValidator.Validate(request);

        if (!validateResult.IsValid)
        {
            return Task.FromResult(new SignInResponse { IsSucceed = false, Error = string.Join(", ", validateResult.Errors) }); 
        }

        _db.Users.Add(new User
        {
            Username = request.Username, Email = request.Email, Password = request.Password
        });
        _db.SaveChanges();

        return Task.FromResult(new SignInResponse
        {
            IsSucceed = true,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 1)),
            RefreshToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 15))
        });
    }
    
    public override Task<LogInResponse> LogInUser(LogInRequest request, ServerCallContext context)
    {
        LogInValidator logInValidator = new LogInValidator();

        if (!logInValidator.Validate(request).IsValid)
        {
            return Task.FromResult(new LogInResponse { IsSucceed = false, Error = "Неверный логин или пароль"});
        }

        return Task.FromResult(new LogInResponse
        {
            IsSucceed = true,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 1)),
            RefreshToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 15))
        });
    }
    
    public override Task<TokenValidationResponse> ValidateToken(TokenValidationRequest request,
        ServerCallContext context)
    {
        var result = RequestManager.ValidateToken(_db, request.AccessToken);

        if (result != null)
        {
            return Task.FromResult(new TokenValidationResponse { IsValid = false, Error = result});
        }

        return Task.FromResult(new TokenValidationResponse { IsValid = true });
    }
    
    public override Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request, ServerCallContext context)
    {
        var result = RequestManager.ValidateToken(_db, request.RefreshToken);

        if (result != null)
        {
            return Task.FromResult(new AccessTokenResponse { IsValid = false, Error = result });
        }

        JwtSecurityToken jwt = new JwtSecurityToken(request.RefreshToken);

        return Task.FromResult(new AccessTokenResponse
        {
            IsValid = true,
            AccessToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(jwt.Claims.First().Value, 1)),
            RefreshToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(jwt.Claims.First().Value, 15))
        });
    }
}