using MediatR;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create;

public class Request : IRequest<Response>
{
    protected Request()
    {
    }

    public Request(string name, string email, string password)
    {
        Name = name;
        Email = email;
        Password = password;
    }
    
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}