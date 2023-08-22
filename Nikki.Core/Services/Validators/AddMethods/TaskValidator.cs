using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators.AddMethods;

public class TaskValidator : AbstractValidator<AddTaskRequest>
{
    public override ValidationResult Validate(ValidationContext<AddTaskRequest> context)
    {
        return base.Validate(context);
    }
}