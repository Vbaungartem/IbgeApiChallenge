using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;

public interface ILocalityListAllRepository
{
    Task<List<LocalityVm>> ListAllAsync(CancellationToken cancellationToken);

}
