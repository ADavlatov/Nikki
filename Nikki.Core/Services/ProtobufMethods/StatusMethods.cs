using Nikki.Core.Models;

namespace Nikki.Core.Services.ProtobufMethods;

public class StatusMethods
{
    public AddStatusResponse Add(AddStatusRequest request, CoreContext db)
    {
        var statusValidator = new Validators.AddMethods.StatusValidator().Validate(request);

        if (statusValidator.IsValid)
        {
            db.Statuses!.Add(new Status
            {
                Name = request.Name, Color = request.Color,
                Table = db.Tables!.FirstOrDefault(x => x.Name == request.TableName && x.Id == request.TableId)!,
                TableId = request.TableId, Tasks = new List<TaskModel>()
            });
            db.SaveChanges();

            return new AddStatusResponse { IsSucceed = true, Status = "Ok" };
        }

        return new AddStatusResponse { IsSucceed = false, Status = string.Join(", ", statusValidator.Errors)};
    }

    public GetStatusesResponse Get(GetStatusesRequest request, CoreContext db)
    {
        var statusValidator = new Validators.GetMethods.StatusValidator().Validate(request);

        if (statusValidator.IsValid)
        {
            var statuses = db.Statuses;
            return new GetStatusesResponse
            {
                IsSucceed = true,
                Status = "Ok",
                StatusesName = string.Join(", ", statuses!.Select(x => x.Name)),
                StatusesColor = string.Join(", ", statuses!.Select(x => x.Color)),
                StatusesId = string.Join(", ", statuses!.Select(x => x.Id))
            };
        }
        return new GetStatusesResponse();
    }
}