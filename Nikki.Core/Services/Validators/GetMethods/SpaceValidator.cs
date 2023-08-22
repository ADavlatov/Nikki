using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.GetMethods;

public class SpaceValidator : AbstractValidator<GetSpacesRequest>
{
    public override ValidationResult Validate(ValidationContext<GetSpacesRequest> context)
    {
        return base.Validate(context);
    }
}