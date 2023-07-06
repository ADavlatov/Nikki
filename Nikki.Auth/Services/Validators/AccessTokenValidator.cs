using System.IdentityModel.Tokens.Jwt;
using FluentValidation;

namespace Nikki.Auth.Services.Validators;

public class AccessTokenValidator : AbstractValidator<TokenValidationRequest>
{
    public AccessTokenValidator()
    {
        RuleFor(x => x).Must(x => new JwtSecurityTokenHandler().CanReadToken(x.AccessToken))
            .WithMessage("Невозможно прочитать токен").NotEmpty().WithMessage("Поле не может быть пустым");
    }
}