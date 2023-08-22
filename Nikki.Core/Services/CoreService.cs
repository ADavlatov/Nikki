using Grpc.Core;
using Nikki.Core.Models;
using Nikki.Core.Services.ProtobufMethods;

namespace Nikki.Core.Services;

public class CoreService : Core.CoreBase
{
    private readonly CoreContext _db;

    public CoreService(CoreContext db)
    {
        _db = db;
    }

    public override Task<AddSpaceResponse> AddSpace(AddSpaceRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SpaceMethods().Add(request, _db));
    }

    public override Task<GetSpacesResponse> GetSpaces(GetSpacesRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SpaceMethods().Get(request, _db));
    }

    public override Task<AddTableResponse> AddTable(AddTableRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TableMethods().Add());
    }

    public override Task<GetTablesResponse> GetTables(GetTablesRequest request, ServerCallContext context)
    {
        return Task.FromResult(new TableMethods().Get());
    }

    public override Task<AddStatusResponse> AddStatus(AddStatusRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StatusMethods().Add(request, _db));
    }

    public override Task<GetStatusesResponse> GetStatuses(GetStatusesRequest request, ServerCallContext context)
    {
        return Task.FromResult(new StatusMethods().Get(request, _db));
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
        return Task.FromResult(new SubtaskMethods().Add());
    }

    public override Task<GetSubtasksResponse> GetSubtasks(GetSubtasksRequest request, ServerCallContext context)
    {
        return Task.FromResult(new SubtaskMethods().Get());
    }
}