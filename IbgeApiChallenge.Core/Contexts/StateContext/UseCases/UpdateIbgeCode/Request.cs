using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateIbgeCode;

public class Request : IRequest<Response>
{
    public string Id { get; set; } = string.Empty;
    public string IbgeCode { get; set; } = string.Empty;
}