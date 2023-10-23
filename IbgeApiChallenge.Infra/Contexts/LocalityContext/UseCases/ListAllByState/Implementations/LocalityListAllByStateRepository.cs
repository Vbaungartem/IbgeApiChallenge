using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAllByState.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.ListAllByState.Implementations;

public class LocalityListAllByStateRepository : ILocalityListAllByStateRepository
{
    private readonly AppDbContext _context;
    public LocalityListAllByStateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<LocalityVm>> ListAllByIdStateAsync(string id, CancellationToken cancellationToken)
    {
        return await GetByPredicate(loc=> loc.StateId == new Guid(id), cancellationToken);
    }

    public async Task<List<LocalityVm>> ListAllByAcronymStateAsync(string acronym, CancellationToken cancellationToken)
    {
        return await GetByPredicate(loc=> loc.State.Acronym == acronym, cancellationToken);
    }
    public async Task<List<LocalityVm>> ListAllByIbgeCodeStateAsync(string ibgeCode, CancellationToken cancellationToken)
    {
        return await GetByPredicate(loc=> loc.State.IbgeCode == ibgeCode, cancellationToken);
    }
    public async Task<List<LocalityVm>> ListAllByNameStateAsync(string name, CancellationToken cancellationToken)
    {
        return await GetByPredicate(loc=> loc.State.Name == name, cancellationToken);
    }

    private async Task<List<LocalityVm>> GetByPredicate(Expression<Func<Locality, bool>> predicate, CancellationToken cancellationToken)
    {
        try
        {
            return await _context.Locality
              .AsNoTracking()
              .Include(locality => locality.State)
              .Where(predicate)
              .Select(loc => new LocalityVm(
                  loc.Id, 
                  loc.Name, 
                  loc.IbgeCode, 
                  loc.State.Name, 
                  loc.StateId)
            ).ToListAsync(cancellationToken: cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
