using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators;

public class AddSpaceValidator : AbstractValidator<AddSpaceRequest>
{
    public override ValidationResult Validate(ValidationContext<AddSpaceRequest> context)
    {
        return base.Validate(context);
    }
}