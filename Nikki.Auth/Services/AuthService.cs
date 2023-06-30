using System.IdentityModel.Tokens.Jwt;
using Grpc.Core;
using Nikki.Auth.Models;

namespace Nikki.Auth.Services;

public class AuthService
{
    private readonly UserContext _db = new();

    public override Task<SignInResponse> SignInUser(SignInRequest request, ServerCallContext context)
    {
        var result = RequestManager.ValidateSignInRequest(_db, request);

        if (result != null)
        {
            return Task.FromResult(new SignInResponse { IsSucceed = false, Error = result });
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
}