using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get;

public class Request : IRequest<Response>
{
    public string Filter { get; set; } = String.Empty;
    public int Type { get; set; } = 0;
}