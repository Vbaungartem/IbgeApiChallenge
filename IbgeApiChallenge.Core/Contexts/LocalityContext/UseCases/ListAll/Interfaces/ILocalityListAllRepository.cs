using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;

public interface ILocalityListAllRepository
{
    Task<List<Locality>> ListAllAsync(CancellationToken cancellationToken);

}
