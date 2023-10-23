using Flunt.Notifications;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get;

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

public record ResponseData(LocalityStateVm locality);
