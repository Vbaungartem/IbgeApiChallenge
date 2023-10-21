using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.UpdatePassword.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.UpdatePassword.Implementations;

public class UserUpdatePassword : IUserUpdatePasswordRepository
{
    private readonly AppDbContext _context;

    public UserUpdatePassword(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetById(string requestId, CancellationToken cancellationToken)
    {
          return await _context
                        .User
                        .Include(user => user!.Roles)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(user => user!.Id.ToString() == requestId, cancellationToken);
    }

    public async Task UpdatePasswordUserAsync(User user, string plainTextPassword,CancellationToken cancellationToken)
    {
        var modelDb = await _context
            .User
            .FirstOrDefaultAsync(user => user.Email.Address == user.Email.Address, cancellationToken: cancellationToken);
        
        modelDb?.UpdatePassword(plainTextPassword);
        await _context.SaveChangesAsync(cancellationToken);
    }
}