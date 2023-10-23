using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Interfaces;

public interface IStateUpdateIbgeCodeRepository
{
    Task<State?> GetByIdAsync(string requestId, CancellationToken cancellationToken);
    Task UpdateAndSaveAsync(CancellationToken cancellationToken);
    Task UpdateLocalityChildrenWithNewStateIbgePrefixAsync(Guid stateId, string ibgeCodeCode, CancellationToken cancellationToken);
}