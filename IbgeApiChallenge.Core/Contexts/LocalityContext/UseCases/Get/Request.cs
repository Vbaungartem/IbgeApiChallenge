using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get;

public class Request : IRequest<Response>
{
    public string Filter { get; set; } = String.Empty;
    public TypeEnum Type { get; set; }
}

public enum TypeEnum
{
    Id = 0,
    IbgeCode = 1,
    Name = 2
}