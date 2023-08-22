using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.AddMethods;

public class StatusValidator : AbstractValidator<AddStatusRequest>
{
    public override ValidationResult Validate(ValidationContext<AddStatusRequest> context)
    {
        return base.Validate(context);
    }
}