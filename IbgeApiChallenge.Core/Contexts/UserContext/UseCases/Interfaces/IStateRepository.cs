using IbgeApiChallenge.Core.Contexts.UserContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Interfaces;

public interface IStateRepository
{
    Task<List<State>> ListAllAsync();
}
