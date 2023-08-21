using Nikki.Core.Models;

namespace Nikki.Core.Services.ProtobufMethods;

public class SpaceMethods
{
    public AddSpaceResponse Add(AddSpaceRequest request, CoreContext? db)
    {
        return new AddSpaceResponse();
    }

    public GetSpacesResponse Get()
    {
        return new GetSpacesResponse();
    }
}