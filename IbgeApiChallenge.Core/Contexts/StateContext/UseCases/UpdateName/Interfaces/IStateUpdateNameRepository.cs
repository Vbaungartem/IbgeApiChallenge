using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateName.Interfaces;

public interface IStateUpdateNameRepository
{
    Task UpdateAndSaveStateAsync(CancellationToken cancellationToken);
    Task<State?> GetByIdAsync(string requestId, CancellationToken cancellationToken);
}