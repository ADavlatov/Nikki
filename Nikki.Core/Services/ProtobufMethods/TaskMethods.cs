using Nikki.Core.Models;

namespace Nikki.Core.Services.ProtobufMethods;

public class TaskMethods
{
    public AddTaskResponse Add(AddTaskRequest request, CoreContext db)
    {
        var taskValidator = new Validators.AddMethods.TaskValidator().Validate(request);

        if (!taskValidator.IsValid)
        {
            return new AddTaskResponse { IsSucceed = false, Status = String.Join(", ", taskValidator.Errors) };
        }

        db.Tasks!.Add(new TaskModel
        {
            Name = request.Name, Priority = request.Priority, StartDate = DateOnly.Parse(request.StartDate),
            DueDate = DateOnly.Parse(request.DueDate),
            Status = db.Statuses!.FirstOrDefault(x => x.Name == request.StatusName && x.Id == request.StatusId)!,
            StatusId = request.StatusId
        });
        db.SaveChanges();

        return new AddTaskResponse { IsSucceed = true, Status = "Ok" };
    }

    public GetTasksResponse Get(GetTasksRequest request, CoreContext db)
    {
        var taskValidator = new Validators.GetMethods.TaskValidator().Validate(request);

        if (!taskValidator.IsValid)
        {
            return new GetTasksResponse { IsSucceed = false, Status = string.Join(", ", taskValidator.Errors) };
        }

        var tasks = db.Tasks;

        return new GetTasksResponse
        {
            IsSucceed = true, TasksId = string.Join(", ", tasks!.Select(x => x.Id)),
            TasksName = string.Join(", ", tasks!.Select(x => x.Name)),
            TasksPriority = string.Join(", ", tasks!.Select(x => x.Priority)),
            TasksStartDate = string.Join(", ", tasks!.Select(x => x.StartDate)),
            TasksDueDate = string.Join(", ", tasks!.Select(x => x.DueDate))
        };
    }
}