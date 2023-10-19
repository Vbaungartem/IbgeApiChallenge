using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Core.Contexts.UserContext.ValueObjects;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.Create.Implementations;

public class UserCreateRepository : IUserCreateRepository
{
    private readonly AppDbContext _context;

    public UserCreateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(string userEmail, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .User
                .AsNoTracking()
                .AnyAsync(user => user.Email.Address == userEmail, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task AppendAndSaveAsync(User? user, CancellationToken cancellationToken)
    {
        await _context.User.AddAsync(user, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}