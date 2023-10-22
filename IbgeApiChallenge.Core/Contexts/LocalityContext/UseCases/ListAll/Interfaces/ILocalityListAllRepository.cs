using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;

public interface ILocalityListAllRepository
{
    Task<List<LocalityVm>> ListAllAsync(CancellationToken cancellationToken);
    Task<List<LocalityVm>> ListAllAsync(string name, CancellationToken cancellationToken);
}
