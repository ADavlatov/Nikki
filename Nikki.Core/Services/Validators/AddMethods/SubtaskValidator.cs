using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.AddMethods;

public class SubtaskValidator : AbstractValidator<AddSubtaskRequest>
{
    public override ValidationResult Validate(ValidationContext<AddSubtaskRequest> context)
    {
        return base.Validate(context);
    }
}