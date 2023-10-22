using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;

public interface IStateGetRepository
{ 
    Task<StateVm?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<StateVm?> GetByAcronymAsync(string acronym, CancellationToken cancellationToken);
    Task<StateVm?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken);
    Task<StateVm?> GetByNameCodeAsync(string name, CancellationToken cancellationToken);
}