using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.Create.Implementations;

public class LocalityCreateRepository : ILocalityCreateRepository
{
    private readonly AppDbContext _context;

    public LocalityCreateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(string requestIbgeCode, CancellationToken cancellationToken)
        => await _context.Locality.AnyAsync(locality => locality.IbgeCode == requestIbgeCode, cancellationToken);

    public async Task AppendAndSaveAsync(Locality locality, CancellationToken cancellationToken)
    {
        await _context.Locality.AddAsync(locality, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}
