using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll;

public class Request : IRequest<Response>
{
  public string Name { get; set; } = string.Empty;
}