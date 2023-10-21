using Flunt.Notifications;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword;

public class Response : SharedContext.UseCases.Response
{
    protected Response()
    {
        
    }

    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }

    public Response(string message, ResponseData? responseData = null)
    {
        Message = message;
        ResponseData = responseData;
        Status = 201;
    }
    public ResponseData? ResponseData { get; set; }
}

public record ResponseData(string Id, string Name, string Email)
{
}