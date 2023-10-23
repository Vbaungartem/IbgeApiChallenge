using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateAcronym.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.UpdateAcronym.Implementations;

public class StateUpdateAcronymRepository : IStateUpdateAcronymRepository
{
    private readonly AppDbContext _context;

    public StateUpdateAcronymRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<State?> GetByIdAsync(string requestId, CancellationToken cancellationToken)
    {
        return await _context
            .State
            .FirstOrDefaultAsync(state => state.Id.ToString() == requestId, cancellationToken);
    }

    public async Task UpdateAndSaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
}