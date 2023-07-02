using FluentValidation;
using Nikki.Auth.Models;

namespace Nikki.Auth.Services.Validators;

public class LogInValidator : AbstractValidator<LogInRequest>
{
    private UserContext _db = new();
    
    public LogInValidator()
    {
        RuleFor(x => _db.Users.FirstOrDefault(y => (y.Username == x.Username || y.Email == x.Username) && y.Password == x.Password));
        RuleFor(x => x.Username).Must(x => x.All(char.IsLetter) || x.All(char.IsNumber)).MaximumLength(16).NotEmpty();
        RuleFor(x => x.Password).Must(x => x.All(char.IsLetter) || x.All(char.IsNumber)).MaximumLength(30).NotEmpty();
    }
}