using IbgeApiChallenge.Core.Contexts.UserContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Interfaces;

public interface IUserAuthenticateRepository
{
    Task<User?> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken);
}