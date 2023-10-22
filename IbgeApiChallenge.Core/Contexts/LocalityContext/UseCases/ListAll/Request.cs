using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll;

public class Request : IRequest<Response>
{
    public int? Sort { get; set; }
}