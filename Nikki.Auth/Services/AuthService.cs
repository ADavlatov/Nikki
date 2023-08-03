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
        var validationResult = signInValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return Task.FromResult(new SignInResponse
            {
                IsSucceed = false,
                UsernameErrors = string.Join(", ",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("username"))),
                EmailErrors = string.Join(", ", validationResult.Errors.Where(x => x.ErrorMessage.Contains("email"))),
                PasswordErrors = string.Join(", ",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("password")))
            });
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
        var validationResult = logInValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return Task.FromResult(new LogInResponse
            {
                IsSucceed = false,
                UsernameErrors = string.Join(",",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("username"))),
                PasswordErrors = string.Join(",",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("password")))
            });
        }

        return Task.FromResult(new LogInResponse
        {
            IsSucceed = true,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 1)),
            RefreshToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 4320))
        });
    }

    public override Task<TokenValidationResponse> ValidateToken(TokenValidationRequest request,
        ServerCallContext context)
    {
        AccessTokenValidator accessTokenValidator = new AccessTokenValidator();
        var validationResult = accessTokenValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return Task.FromResult(new TokenValidationResponse
                { IsValid = false, Error = string.Join(", ", validationResult.Errors) });
        }

        return Task.FromResult(new TokenValidationResponse { IsValid = true });
    }

    public override Task<AccessTokenResponse> GetAccessToken(AccessTokenRequest request, ServerCallContext context)
    {
        RefreshTokenValidator refreshTokenValidator = new RefreshTokenValidator();
        var validationResult = refreshTokenValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return Task.FromResult(new AccessTokenResponse
                { IsValid = false, Error = string.Join(", ", validationResult.Errors) });
        }

        JwtSecurityToken jwt = new JwtSecurityToken(request.RefreshToken);

        return Task.FromResult(new AccessTokenResponse
        {
            IsValid = true,
            AccessToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(jwt.Claims.First().Value, 1)),
            RefreshToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(jwt.Claims.First().Value, 15))
        });
    }
}