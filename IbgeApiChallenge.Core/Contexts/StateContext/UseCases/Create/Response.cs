using Flunt.Notifications;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create;

public class Response : SharedContext.UseCases.Response
{
    protected Response()
    {
    }

    public Response(string message, ResponseData? responseData = null)
    {
        Message = message;
        Status = 201;
        ResponseData = responseData;
    }

    public Response(string message, int status, IEnumerable<Notification>? notifications = null)
    {
        Message = message;
        Status = status;
        Notifications = notifications;
    }
    
    public ResponseData? ResponseData { get; set; }
}

public record ResponseData(Guid Id, string IbgeCode, string Name, string Acronym)
{
}