using IbgeApiChallenge.Core.Contexts.UserContext.Entities;

namespace IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword.Interfaces;

public interface IUserUpdatePasswordRepository
{
    Task<User?> GetById(string requestId, CancellationToken cancellationToken);
    Task UpdatePasswordUserAsync(User user, string plainTextPassword, CancellationToken cancellationToken);
}