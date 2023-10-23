using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAllByState.Interfaces;

public interface ILocalityListAllByStateRepository
{
    Task<List<LocalityVm>> ListAllByIdStateAsync(string id, CancellationToken cancellationToken);
    Task<List<LocalityVm>> ListAllByAcronymStateAsync(string acronym, CancellationToken cancellationToken);
    Task<List<LocalityVm>> ListAllByIbgeCodeStateAsync(string ibgeCode, CancellationToken cancellationToken);
    Task<List<LocalityVm>> ListAllByNameStateAsync(string name, CancellationToken cancellationToken);
}
