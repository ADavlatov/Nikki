using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.GetMethods;

public class StatusValidator : AbstractValidator<GetStatusesRequest>
{
    public override ValidationResult Validate(ValidationContext<GetStatusesRequest> context)
    {
        return base.Validate(context);
    }
}