using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.GetMethods;

public class TaskValidator : AbstractValidator<GetTasksRequest>
{
    public override ValidationResult Validate(ValidationContext<GetTasksRequest> context)
    {
        return base.Validate(context);
    }
}