using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll;

public class Request : IRequest<Response>
{
    public int? Sort { get; set; }
}