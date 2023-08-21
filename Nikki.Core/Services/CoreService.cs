using Grpc.Core;
using Nikki.Core.Services.ProtobufMethods;

namespace Nikki.Core.Services;

public class CoreService : Core.CoreBase
{
    public override Task<AddSpaceResponse> AddSpace(AddSpaceRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Space().Add());
    }

    public override Task<GetSpacesResponse> GetSpaces(GetSpacesRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Space().Get());
    }

    public override Task<AddTableResponse> AddTable(AddTableRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Table().Add());
    }

    public override Task<GetTablesResponse> GetTables(GetTablesRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Table().Get());
    }

    public override Task<AddStatusResponse> AddStatus(AddStatusRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StatusMethods().Add());
    }

    public override Task<GetStatusesResponse> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StatusMethods().Get());
    }

    public override Task<AddTaskResponse> AddTask(AddTaskRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TaskMethods().Add());
    }

    public override Task<GetTasksResponse> GetTasks(GetTasksRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TaskMethods().Get());
    }

    public override Task<AddSubtaskResponse> AddSubtask(AddSubtaskRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Subtask().Add());
    }

    public override Task<GetSubtasksResponse> GetSubtasks(GetSubtasksRequest request, ServerCallContext context)
    {
        return Task.FromResult(new Subtask().Get());
    }
}