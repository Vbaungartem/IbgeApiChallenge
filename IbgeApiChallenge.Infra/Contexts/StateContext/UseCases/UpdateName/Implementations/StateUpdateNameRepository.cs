using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateName.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Update.Implementations;

public class StateUpdateNameRepository : IStateUpdateNameRepository
{
    private readonly AppDbContext _context;

    public StateUpdateNameRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task UpdateAndSaveStateAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task<State?> GetByIdAsync(string requestId, CancellationToken cancellationToken)
    {
        return await _context.State.FirstOrDefaultAsync(state => state.Id.ToString() == requestId, cancellationToken);
    }
}