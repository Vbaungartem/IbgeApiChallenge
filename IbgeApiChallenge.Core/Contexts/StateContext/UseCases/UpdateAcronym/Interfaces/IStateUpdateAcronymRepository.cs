using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateAcronym.Interfaces;

public interface IStateUpdateAcronymRepository
{
    Task<State?> GetByIdAsync(string requestId, CancellationToken cancellationToken);
    Task UpdateAndSaveAsync(CancellationToken cancellationToken);
}