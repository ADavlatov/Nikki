using FluentValidation;
using FluentValidation.Validators;
using Nikki.Auth.Models;

namespace Nikki.Auth.Services.Validators;

public class SignInValidator : AbstractValidator<User>
{
    public SignInValidator()
    {
        RuleFor(x => x.Username).Must(x => x.All(char.IsLetter) || x.All(char.IsNumber))
            .WithMessage("Имя пользователя должно состоять только из букв и цифр.").MaximumLength(16)
            .WithMessage("Имя пользователя не должно превышать длину в 16 символов.").NotEmpty()
            .WithMessage("Введите имя пользователяю.");
        RuleFor(x => x.Password).Must(x => x.All(char.IsLetter) || x.All(char.IsNumber))
            .WithMessage("Пароль должен состоять только из букв и цифр.").MaximumLength(30)
            .WithMessage("Пароль не должен превышать длину в 16 символов.").NotEmpty()
            .WithMessage("Введите пароль.");
        RuleFor(x => x.Email).NotEmpty().EmailAddress(mode: EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Ошибка при вводе электронной почты.");
    }
}