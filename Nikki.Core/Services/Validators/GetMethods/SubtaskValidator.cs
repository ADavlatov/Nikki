using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.GetMethods;

public class SubtaskValidator : AbstractValidator<GetSubtasksRequest>
{
    public override ValidationResult Validate(ValidationContext<GetSubtasksRequest> context)
    {
        return base.Validate(context);
    }
}