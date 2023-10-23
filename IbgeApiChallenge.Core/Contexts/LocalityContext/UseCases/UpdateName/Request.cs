using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateName;

public class Request : IRequest<Response>
{
    public string Id { get; set; } = string.Empty;
    public string  Name { get; set; } = string.Empty;
}