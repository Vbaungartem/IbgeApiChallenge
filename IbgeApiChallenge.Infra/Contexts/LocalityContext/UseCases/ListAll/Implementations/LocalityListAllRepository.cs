using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.ListAll.Implementations;

public class LocalityListAllRepository : ILocalityListAllRepository
{
    private readonly AppDbContext _context;

    public LocalityListAllRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Locality>> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Locality
            .AsNoTracking()
            .ToListAsync(cancellationToken: cancellationToken);
    }

}
