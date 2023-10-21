using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;

public interface IStateCreateRepository
{
    Task<bool> AnyAsync(string requestIbgeCode, CancellationToken cancellationToken);
    Task AppendAndSaveAsync(State state, CancellationToken cancellationToken);
}