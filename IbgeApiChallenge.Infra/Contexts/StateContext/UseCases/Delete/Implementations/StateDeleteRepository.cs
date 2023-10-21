using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Delete.Implementations;

public class StateDeleteRepository : IStateDeleteRepository
{
    private readonly AppDbContext _context;

    public StateDeleteRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(string requestId, CancellationToken cancellationToken)
        => await _context.State
            .AnyAsync(state => state.Id.ToString() == requestId, cancellationToken);

    public async Task DeleteStateAsync(string requestId, CancellationToken cancellationToken)
    {
        var state = await _context.State.FirstOrDefaultAsync(state => state.Id.ToString() == requestId, cancellationToken);
        try
        {
            _context.State.Remove(state);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        
        
    }
}