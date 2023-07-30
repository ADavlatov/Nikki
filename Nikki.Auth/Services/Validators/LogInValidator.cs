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
            .WithMessage("Invalid username or password");
        RuleFor(x => x.Username).MinimumLength(4)
            .WithMessage("The username or email must consist of at least 4 characters").MaximumLength(30).NotEmpty()
            .WithMessage("Enter your username or email");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Enter the password");
    }
}