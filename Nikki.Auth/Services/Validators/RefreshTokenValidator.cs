using System.IdentityModel.Tokens.Jwt;
using FluentValidation;

namespace Nikki.Auth.Services.Validators;

public class RefreshTokenValidator : AbstractValidator<AccessTokenRequest>
{
    public RefreshTokenValidator()
    {
        JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();
        RuleFor(x => x.RefreshToken).Must(x => jwt.CanReadToken(x))
            .WithMessage("The token cannot be read").NotEmpty().WithMessage("The field cannot be empty");
    }
}