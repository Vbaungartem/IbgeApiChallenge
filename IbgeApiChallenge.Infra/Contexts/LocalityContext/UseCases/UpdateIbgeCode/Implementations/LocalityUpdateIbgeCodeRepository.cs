using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateIbgeCode.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.UpdateIbgeCode.Implementations;

public class LocalityUpdateIbgeCodeRepository : ILocalityUpdateIbgeCodeRepository
{
    private readonly AppDbContext _context;

    public LocalityUpdateIbgeCodeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<Locality?> GetByIdAsync(string requestId, CancellationToken cancellationToken)
        => await _context.Locality
            .FirstOrDefaultAsync(loc => loc.Id.ToString() == requestId, cancellationToken);

    public async Task UpdateAndSaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);
}