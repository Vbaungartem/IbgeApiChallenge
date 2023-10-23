using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateName.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.UpdateName.Implementations;

public class LocalityUpdateNameRepository : ILocalityUpdateNameRepository
{

    private readonly AppDbContext _context;

    public LocalityUpdateNameRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task UpdateAndSaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task<Locality?> GetByIdAsync(string requestId, CancellationToken cancellationToken)
        => await _context
            .Locality
            .FirstOrDefaultAsync(loc => loc.Id.ToString() == requestId, cancellationToken);
}