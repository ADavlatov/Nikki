using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators;

public class AddStatusValidator : AbstractValidator<AddSpaceRequest>
{
    public override ValidationResult Validate(ValidationContext<AddSpaceRequest> context)
    {
        return base.Validate(context);
    }
}