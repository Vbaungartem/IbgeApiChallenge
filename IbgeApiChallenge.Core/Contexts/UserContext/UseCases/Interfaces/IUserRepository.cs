using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Interfaces;

public interface IUserRepository
{
    Task<bool> AnyAsync(string userEmail, CancellationToken cancellationToken);
    Task AppendAndSaveAsync(User user, CancellationToken cancellationToken);
}