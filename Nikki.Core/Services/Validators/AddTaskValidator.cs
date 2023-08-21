using FluentValidation;
using FluentValidation.Results;

namespace Nikki.Core.Services.Validators;

public class AddTaskValidator : AbstractValidator<AddTaskRequest>
{
    public override ValidationResult Validate(ValidationContext<AddTaskRequest> context)
    {
        return base.Validate(context);
    }
}