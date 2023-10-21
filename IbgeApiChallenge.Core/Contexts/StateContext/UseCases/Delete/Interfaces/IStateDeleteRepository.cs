namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete.Interfaces;

public interface IStateDeleteRepository
{
    Task<bool> AnyAsync(string requestId, CancellationToken cancellationToken);
    Task DeleteStateAsync(string requestId, CancellationToken cancellationToken);
}