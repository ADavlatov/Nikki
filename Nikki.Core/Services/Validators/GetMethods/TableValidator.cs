using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.GetMethods;

public class TableValidator : AbstractValidator<GetTablesRequest>
{
    public override ValidationResult Validate(ValidationContext<GetTablesRequest> context)
    {
        return base.Validate(context);
    }
}