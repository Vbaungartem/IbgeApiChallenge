
using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create.Interfaces;

public interface ILocalityCreateRepository
{
    Task<bool> AnyAsync(string ibgeCode, CancellationToken cancellationToken);
    Task AppendAndSaveAsync(Locality locality, CancellationToken cancellationToken);
}
