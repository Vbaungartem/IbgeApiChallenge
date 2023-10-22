using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;

public interface IStateListAllRepository
{
    Task<List<StateVm>?> ListAllAsync(CancellationToken cancellationToken);
    Task<List<StateVm>?> ListAllAsync(string name, CancellationToken cancellationToken);
}