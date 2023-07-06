using FluentValidation;
using FluentValidation.Validators;
using Nikki.Auth.Models;

namespace Nikki.Auth.Services.Validators;

public class SignInValidator : AbstractValidator<SignInRequest>
{
    private UserContext _db = new();

    public SignInValidator()
    {
        RuleFor(x => x.Username).Must(x => x.All(char.IsLetter) || x.All(char.IsNumber))
            .WithMessage("Имя пользователя должно состоять только из букв и цифр.")
            .Must(x => !_db.Users.Any(y => y.Username == x))
            .WithMessage("Пользователь с таким именем уже существует.").MinimumLength(4)
            .WithMessage("Имя пользователя должно состоять минимум из 4 символов").MaximumLength(16)
            .WithMessage("Имя пользователя не должно превышать длину в 16 символов.").NotEmpty()
            .WithMessage("Введите имя пользователяю.");
        RuleFor(x => x.Password).Must(x => x.All(char.IsLetter) || x.All(char.IsNumber))
            .WithMessage("Пароль должен состоять только из букв и цифр.").MinimumLength(5)
            .WithMessage("Пароль должен состоять минимум из 5 символов").MaximumLength(30)
            .WithMessage("Пароль не должен превышать длину в 16 символов.").NotEmpty()
            .WithMessage("Введите пароль.");
        RuleFor(x => x.Email).Must(x => !_db.Users.Any(y => y.Email == x))
            .WithMessage("Пользователь с таким адресом электронной почты уже существует.").NotEmpty()
            .EmailAddress(mode: EmailValidationMode.AspNetCoreCompatible)
            .WithMessage("Ошибка при вводе электронной почты.");
    }
}