using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create;

public class Request : IRequest<Response>
{
    protected Request()
    {
    }

    public Request(string ibgeCode, string name, string acronym)
    {
        IbgeCode = ibgeCode;
        Name = name;
        Acronym = acronym;
    }
    
    public string IbgeCode { get;  set; } = String.Empty;
    public string Name { get; set; } = string.Empty;
    public string Acronym { get; set; } = string.Empty;
}