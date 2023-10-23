using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get.Interfaces;

public interface ILocalityGetRepository
{
    Task<LocalityStateVm?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<LocalityStateVm?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken);
    Task<LocalityStateVm?> GetByNameCodeAsync(string name, CancellationToken cancellationToken);
}
