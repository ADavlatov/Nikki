using Nikki.Core.Models;

namespace Nikki.Core.Services.ProtobufMethods;

public class SubtaskMethods
{
    public AddSubtaskResponse Add(AddSubtaskRequest request, CoreContext db)
    {
        var subtaskValidator = new Validators.AddMethods.SubtaskValidator().Validate(request);

        if (!subtaskValidator.IsValid)
        {
            return new AddSubtaskResponse
            {
                IsSucceed = false, Status = string.Join(", ", subtaskValidator.Errors)
            };
        }

        db.Subtasks!.Add(new Subtask
        {
            Name = request.Name, Priority = request.Priority,
            Task = db.Tasks!.FirstOrDefault(x => x.Name == request.TaskName && x.Id == request.TaskId)!,
            TaskId = request.TaskId
        });
        db.SaveChanges();

        return new AddSubtaskResponse
        {
            IsSucceed = true, Status = "Ok"
        };
    }

    public GetSubtasksResponse Get(GetSubtasksRequest request, CoreContext db)
    {
        var subtaskValidator = new Validators.GetMethods.SubtaskValidator().Validate(request);

        if (!subtaskValidator.IsValid)
        {
            return new GetSubtasksResponse { IsSucceed = false, Status = string.Join(", ", subtaskValidator.Errors) };
        }

        var subtasks = db.Subtasks;

        return new GetSubtasksResponse
        {
            IsSucceed = true, SubtasksId = string.Join(", ", subtasks!.Select(x => x.Id)),
            SubtasksName = string.Join(", ", subtasks!.Select(x => x.Name)),
            SubtasksPriority = string.Join(", ", subtasks!.Select(x => x.Priority)), Status = "Ok"
        };
    }
}