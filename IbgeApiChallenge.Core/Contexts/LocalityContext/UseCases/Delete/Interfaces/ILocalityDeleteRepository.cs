
namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete.Interfaces;

public interface ILocalityDeleteRepository
{
    Task<bool> AnyAsync(string requestId, CancellationToken cancellationToken);
    Task DeleteLocalityAsync(string requestId, CancellationToken cancellationToken);
}
