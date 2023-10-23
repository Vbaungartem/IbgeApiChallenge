using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateAcronym;

public class Request : IRequest<Response>
{
    public string Id { get; set; } = string.Empty;
    public string Acronym { get; set; } = string.Empty;
}