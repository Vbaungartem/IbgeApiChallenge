using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.Authenticate.Implementations;

public class UserAuthenticateRepository : IUserAuthenticateRepository
{
    private readonly AppDbContext _context;
    
    public UserAuthenticateRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<User?> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .User
                .AsNoTracking()
                .Include(user => user.Roles)
                .FirstOrDefaultAsync(user => user.Email.Address == requestEmail, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}