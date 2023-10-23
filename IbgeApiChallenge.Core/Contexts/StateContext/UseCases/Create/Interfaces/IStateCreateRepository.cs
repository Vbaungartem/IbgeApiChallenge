using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;

public interface IStateCreateRepository
{
    Task<bool> AnyAsync(string requestIbgeCode, string requestAcronym, CancellationToken cancellationToken);
    Task AppendAndSaveAsync(State state, CancellationToken cancellationToken);
}