using System.IdentityModel.Tokens.Jwt;
using FluentValidation;

namespace Nikki.Auth.Services.Validators;

public class RefreshTokenValidator : AbstractValidator<AccessTokenRequest>
{
    public RefreshTokenValidator()
    {
        RuleFor(x => x).Must(x => new JwtSecurityTokenHandler().CanReadToken(x.RefreshToken))
            .WithMessage("Невозможно прочитать токен").NotEmpty().WithMessage("Поле не может быть пустым");
    }
}