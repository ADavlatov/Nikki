using Nikki.Core.Models;

namespace Nikki.Core.Services.ProtobufMethods;

public class TableMethods
{
    public AddTableResponse Add(AddTableRequest request, CoreContext db)
    {
        var tableValidator = new Validators.AddMethods.TableValidator().Validate(request);

        if (!tableValidator.IsValid)
        {
            return new AddTableResponse { IsSucceed = false, Status = string.Join(", ", tableValidator.Errors) };
        }

        db.Tables!.Add(new Table
        {
            Name = request.Name,
            Space = db.Spaces!.FirstOrDefault(x =>
                x.Name == request.SpaceName && x.Id == request.SpaceId && x.UserId == request.UserId)!,
            SpaceId = request.SpaceId, Statuses = new List<Status>()
        });
        db.SaveChanges();

        return new AddTableResponse { IsSucceed = true, Status = "Ok" };
    }

    public GetTablesResponse Get(GetTablesRequest request, CoreContext db)
    {
        var tableValidator = new Validators.GetMethods.TableValidator().Validate(request);

        if (!tableValidator.IsValid)
        {
            return new GetTablesResponse { IsSucceed = false, Status = string.Join(", ", tableValidator.Errors) };
        }

        var tables = db.Tables;

        return new GetTablesResponse
        {
            IsSucceed = true, TablesId = string.Join(", ", tables!.Select(x => x.Id)),
            TablesName = string.Join(", ", tables!.Select(x => x.Name)), Status = "Ok"
        };
    }
}