using Flunt.Notifications;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate;

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

    public Response(string message, ResponseData responseData)
    {
        Message = message;
        Status = 200;
        ResponseData = responseData;
    }
    
    public ResponseData? ResponseData { get; set; }
}    
public class ResponseData
{
    public ResponseData(string id, string name, string email, string[] roles)
    {
        Id = id;
        Name = name;
        Email = email;
        Roles = roles;
    }

    public void SetToken(string token)
    {
        Token = token;
    }
    
    public string Token { get; private set; } = string.Empty;
    public string Id { get; private set; } = string.Empty;
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string[] Roles { get; private set; } = Array.Empty<string>();
}