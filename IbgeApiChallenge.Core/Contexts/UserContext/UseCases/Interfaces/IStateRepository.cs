using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Interfaces;

public interface IStateRepository
{
    Task<List<State>> ListAllAsync();
}
