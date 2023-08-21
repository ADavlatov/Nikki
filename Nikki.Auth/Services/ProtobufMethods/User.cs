using System.IdentityModel.Tokens.Jwt;
using Nikki.Auth.Models;
using Nikki.Auth.Services.Validators;

namespace Nikki.Auth.Services.ProtobufMethods;

public class User
{
    public SignInResponse SignIn(SignInRequest request, UserContext db)
    {
        SignInValidator signInValidator = new SignInValidator();
        var validationResult = signInValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return new SignInResponse
            {
                IsSucceed = false,
                UsernameErrors = string.Join(", ",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("username"))),
                EmailErrors = string.Join(", ", validationResult.Errors.Where(x => x.ErrorMessage.Contains("email"))),
                PasswordErrors = string.Join(", ",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("password")))
            };
        }

        db.Users!.Add(new UserModel
        {
            Username = request.Username, Email = request.Email, Password = request.Password
        });
        db.SaveChanges();

        return new SignInResponse
        {
            IsSucceed = true,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 1)),
            RefreshToken =
                new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 15)),
            UserId = db.Users.FirstOrDefault(x =>
                    x.Username == request.Username && x.Email == request.Email && x.Password == request.Password)!.Id
                .ToString()
        };
    }

    public LogInResponse LogIn(LogInRequest request, UserContext db)
    {
        LogInValidator logInValidator = new LogInValidator();
        var validationResult = logInValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return new LogInResponse
            {
                IsSucceed = false,
                UsernameErrors = string.Join(",",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("username"))),
                PasswordErrors = string.Join(",",
                    validationResult.Errors.Where(x => x.ErrorMessage.Contains("password")))
            };
        }

        return new LogInResponse
        {
            IsSucceed = true,
            AccessToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 1)),
            RefreshToken = new JwtSecurityTokenHandler().WriteToken(TokenService.GetJwtToken(request.Username, 4320)),
            UserId = db.Users!.FirstOrDefault(x =>
                    (x.Username == request.Username || x.Email == request.Username) && x.Password == request.Password)!
                .Id
                .ToString()
        };
    }
}