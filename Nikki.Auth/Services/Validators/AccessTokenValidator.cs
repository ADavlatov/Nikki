using System.IdentityModel.Tokens.Jwt;
using FluentValidation;

namespace Nikki.Auth.Services.Validators;

public class AccessTokenValidator : AbstractValidator<TokenValidationRequest>
{
    public AccessTokenValidator()
    {
        JwtSecurityTokenHandler jwt = new JwtSecurityTokenHandler();
        RuleFor(x => x.AccessToken).Must(x => jwt.CanReadToken(x))
            .WithMessage("The token cannot be read").NotEmpty().WithMessage("The field cannot be empty");
    }
}