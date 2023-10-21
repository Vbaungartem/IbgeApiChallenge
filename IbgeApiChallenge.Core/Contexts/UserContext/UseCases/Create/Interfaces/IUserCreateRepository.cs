using IbgeApiChallenge.Core.Contexts.UserContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create.Interfaces;

public interface IUserCreateRepository
{
    Task<bool> AnyAsync(string userEmail, CancellationToken cancellationToken);
    Task AppendAndSaveAsync(User? user, CancellationToken cancellationToken);
}