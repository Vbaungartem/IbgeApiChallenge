using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete;

public class Request : IRequest<Response>
{
    public string Id { get; set; } = String.Empty;
}