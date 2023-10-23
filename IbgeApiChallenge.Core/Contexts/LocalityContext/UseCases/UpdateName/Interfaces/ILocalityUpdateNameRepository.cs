using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateName.Interfaces;

public interface ILocalityUpdateNameRepository
{
    Task UpdateAndSaveAsync(CancellationToken cancellationToken);
    Task<Locality?> GetByIdAsync(string requestId, CancellationToken cancellationToken);
}