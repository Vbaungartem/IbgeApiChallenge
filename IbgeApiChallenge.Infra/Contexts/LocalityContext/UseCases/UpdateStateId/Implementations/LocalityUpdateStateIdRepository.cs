using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateState.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.UpdateStateId.Implementations;

public class LocalityUpdateStateRepository : ILocalityUpdateStateRepository
{
    private readonly AppDbContext _context;

    public LocalityUpdateStateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Locality?> GetLocalityByIdAsync(string requestId, CancellationToken cancellationToken)
        => await _context.Locality.FirstOrDefaultAsync(loc => loc.Id.ToString() == requestId, cancellationToken);
    

    public async Task<State?> GetStateByIdAsync(string requestStateId, CancellationToken cancellationToken)
        => await _context.State.FirstOrDefaultAsync(state => state.Id.ToString() == requestStateId, cancellationToken);

    public async Task UpdateAndSaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}