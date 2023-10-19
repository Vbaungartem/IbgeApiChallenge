using MediatR;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate;

public class Request : IRequest<Response>
{
    protected Request()
    {
    }

    public Request(string email, string password)
    {
        Email = email;
        Password = password;
    }
    
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
