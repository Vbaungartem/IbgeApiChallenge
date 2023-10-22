using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create;

public class Request : IRequest<Response>
{
    protected Request()
    {
    }

    public Request(string ibgeCode, string name, string stateId)
    {
        IbgeCode = ibgeCode;
        Name = name;
        StateId = stateId;
    }

    public string IbgeCode { get; set; } = String.Empty;
    public string Name { get; set; } = string.Empty;
    public string StateId { get; set; } = string.Empty;
}