using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get;

public class Request : IRequest<Response>
{
    public string Filter { get; set; } = String.Empty;
    public TypeEnum Type { get; set; } = 0;
}

public enum TypeEnum
{
    Id = 0,
    Acronym = 1,
    IbgeCode = 2,
    Name = 3
}