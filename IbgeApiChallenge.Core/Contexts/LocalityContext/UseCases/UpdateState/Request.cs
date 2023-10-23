using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateState;

public class Request : IRequest<Response>
{
    public string Id { get; set; } = string.Empty;
    public string StateId { get; set; } = string.Empty;
}