using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateIbgeCode;

public class Request : IRequest<Response>
{
    public string Id { get; set; }
    public string IbgeCode { get; set; }
}