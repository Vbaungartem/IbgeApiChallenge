using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;

public interface IStateListAllRepository
{
    Task<List<State>?> ListAllAsync(CancellationToken cancellationToken);
}