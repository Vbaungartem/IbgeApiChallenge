using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAllByState;

public class Request : IRequest<Response>
{
    public string Filter { get; set; } = string.Empty;
    public TypeEnum Type { get; set; }
}

public enum TypeEnum
{
    Id = 0,
    Acronym = 1,
    IbgeCode = 2,
    Name = 3
}