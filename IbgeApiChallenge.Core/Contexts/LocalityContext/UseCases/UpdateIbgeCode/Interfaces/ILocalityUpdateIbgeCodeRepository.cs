using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateIbgeCode.Interfaces;

public interface ILocalityUpdateIbgeCodeRepository
{
    Task<Locality?> GetByIdAsync(string requestId, CancellationToken cancellationToken);
    Task UpdateAndSaveAsync(CancellationToken cancellationToken);
}