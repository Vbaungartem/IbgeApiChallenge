using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;

public interface IStateGetRepository
{ 
    Task<State?> GetByIdAsync(string id, CancellationToken cancellationToken);
    Task<State?> GetByAcronymAsync(string acronym, CancellationToken cancellationToken);
    Task<State?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken);
    Task<State?> GetByNameCodeAsync(string name, CancellationToken cancellationToken);
}