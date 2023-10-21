using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.ListAll.Implementations;

public class StateListAllRepository : IStateListAllRepository
{
    private readonly AppDbContext _context;

    public StateListAllRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<State>?> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _context.State
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }
}