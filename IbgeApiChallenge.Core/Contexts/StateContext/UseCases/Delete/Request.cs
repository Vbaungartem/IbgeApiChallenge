using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete;

public class Request : IRequest<Response>
{
    public string Id { get; set; } = String.Empty;
}