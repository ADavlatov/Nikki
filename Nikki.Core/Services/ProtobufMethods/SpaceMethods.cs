using Nikki.Core.Models;

namespace Nikki.Core.Services.ProtobufMethods;

public class SpaceMethods
{
    public AddSpaceResponse Add(AddSpaceRequest request, CoreContext db)
    {
        var spaceValidator = new Validators.AddMethods.SpaceValidator().Validate(request);

        if (!spaceValidator.IsValid)
        {
            return new AddSpaceResponse { IsSucceed = false, Status = string.Join(", ", spaceValidator.Errors) };
        }

        db.Spaces!.Add(new Space { Name = request.Name, UserId = request.UserId, Tables = new List<Table>() });
        db.SaveChanges();

        return new AddSpaceResponse { IsSucceed = true, Status = "Ok" };
    }

    public GetSpacesResponse Get(GetSpacesRequest request, CoreContext db)
    {
        var spaceValidator = new Validators.GetMethods.SpaceValidator().Validate(request);

        if (!spaceValidator.IsValid)
        {
            return new GetSpacesResponse
            {
                IsSucceed = false, Status = string.Join(", ", spaceValidator.Errors)
            };
        }

        return new GetSpacesResponse
        {
            SpacesId = string.Join(", ", db.Spaces!.Select(x => x.Id)),
            SpacesName = string.Join(", ", db.Spaces!.Select(x => x.Name)),
            IsSucceed = true
        };
    }
}