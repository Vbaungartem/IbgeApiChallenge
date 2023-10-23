using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateState.Interfaces;

public interface ILocalityUpdateStateRepository
{
    Task<Locality?> GetLocalityByIdAsync(string requestId, CancellationToken cancellationToken);
    Task<State?> GetStateByIdAsync(string requestStateId, CancellationToken cancellationToken);
    Task UpdateAndSaveAsync(CancellationToken cancellationToken);
}