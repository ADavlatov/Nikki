using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators;

public class AddTableValidator : AbstractValidator<AddTableRequest>
{
    public override ValidationResult Validate(ValidationContext<AddTableRequest> context)
    {
        return base.Validate(context);
    }
}