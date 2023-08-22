using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.AddMethods;

public class StatusValidator : AbstractValidator<AddSpaceRequest>
{
    public override ValidationResult Validate(ValidationContext<AddSpaceRequest> context)
    {
        return base.Validate(context);
    }
}