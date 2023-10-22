using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
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
    public async Task<List<LocalityVm>> ListAllAsync(CancellationToken cancellationToken)
    {
        var list = await _context.Locality
            .AsNoTracking()
            .Include(locality => locality.State)
            .Select(loc => new LocalityVm(
                loc.Id, 
                loc.Name, 
                loc.IbgeCode, 
                loc.State.Name, 
                loc.StateId)
            ).ToListAsync(cancellationToken: cancellationToken);
        return list;
    }
}
