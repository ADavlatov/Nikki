namespace Nikki.Core.Services.ProtobufMethods;

public class StatusMethods
{
    public AddStatusResponse Add()
    {
        return new AddStatusResponse();
    }

    public GetStatusesResponse Get()
    {
        return new GetStatusesResponse();
    }
}