using MediatR;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword;

public class Request : IRequest<Response>
{

    protected Request()
    {
    }

    public Request(string oldPassword, string newPassword)
    {
        OldPassword = oldPassword;
        NewPassword = newPassword;
        Id = string.Empty;
    }

    public void SetId(string id)
    {
        Id = id;
    }

    public void SetRequestedId(string id)
    {
        RequestedId = id;
    }
    public string Id { get; private set; } = string.Empty;
    public string RequestedId { get; private set; } = string.Empty;
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}