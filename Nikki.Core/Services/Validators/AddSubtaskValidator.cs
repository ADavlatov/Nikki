using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators;

public class AddSubtaskValidator : AbstractValidator<AddSubtaskRequest>
{
    public override ValidationResult Validate(ValidationContext<AddSubtaskRequest> context)
    {
        return base.Validate(context);
    }
}