using Flunt.Notifications;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete;

public class Response : SharedContext.UseCases.Response
{
    protected Response()
    {
    }

    public Response(string message, ResponseData responseData)
    {
        Message = message;
        Status = 200;
        ResponseData = responseData;
    }

    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }
    public ResponseData? ResponseData { get; }
}

public record ResponseData(string Id)
{
}