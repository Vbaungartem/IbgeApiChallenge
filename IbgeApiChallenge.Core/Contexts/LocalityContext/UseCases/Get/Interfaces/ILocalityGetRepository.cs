using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get.Interfaces;

public interface ILocalityGetRepository
{
    Task<Locality?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<Locality?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken);
    Task<Locality?> GetByNameCodeAsync(string name, CancellationToken cancellationToken);
}
