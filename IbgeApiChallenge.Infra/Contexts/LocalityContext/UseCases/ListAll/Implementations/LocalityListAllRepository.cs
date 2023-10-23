using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;
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
        return await _context.Locality
          .AsNoTracking()
          .Include(locality => locality.State)
          .Select(loc => new LocalityVm(
              loc.Id, 
              loc.Name, 
              loc.IbgeCode, 
              loc.State.Name, 
              loc.StateId)
        ).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<List<LocalityVm>> ListAllAsync(string name, CancellationToken cancellationToken)
    {
        return await _context.Locality
          .AsNoTracking()
          .Include(locality => locality.State)
          .Where(locality => locality.Name.ToLower().Contains(name.ToLower()))
          .Select(loc => new LocalityVm(
              loc.Id, 
              loc.Name, 
              loc.IbgeCode, 
              loc.State.Name, 
              loc.StateId)
        ).ToListAsync(cancellationToken: cancellationToken);
    }
}
