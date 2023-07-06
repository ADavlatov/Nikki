using FluentValidation;
using Nikki.Auth.Models;

namespace Nikki.Auth.Services.Validators;

public class LogInValidator : AbstractValidator<LogInRequest>
{
    private UserContext _db = new();

    public LogInValidator()
    {
        RuleFor(x => x)
            .Must(x => _db.Users.FirstOrDefault(y =>
                (y.Username == x.Username || y.Email == x.Username) && y.Password == x.Password) != null)
            .WithMessage("Неверный логин или пароль").NotEmpty().WithMessage("Это поле обязательно для заполнения");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Это поле обязательно для заполнения");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Это поле обязательно для заполнения");
    }
}