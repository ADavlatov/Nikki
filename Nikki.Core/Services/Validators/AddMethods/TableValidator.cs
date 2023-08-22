using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.AddMethods;

public class TableValidator : AbstractValidator<AddTableRequest>
{
    public override ValidationResult Validate(ValidationContext<AddTableRequest> context)
    {
        return base.Validate(context);
    }
}