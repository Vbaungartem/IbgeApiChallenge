using System.Linq.Expressions;
using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.Get.Implementations;

public class LocalityGetRepository : ILocalityGetRepository
{
    private readonly AppDbContext _context;

    public LocalityGetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<LocalityStateVm?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken)
    {
        return await GetByPredicate(locality => locality.IbgeCode == ibgeCode, cancellationToken);
    }

    public async Task<LocalityStateVm?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await GetByPredicate(locality => locality.Id == new Guid(id), cancellationToken);
    }

    public async Task<LocalityStateVm?> GetByNameCodeAsync(string name, CancellationToken cancellationToken)
    {
        return await GetByPredicate(locality => locality.Name == name, cancellationToken);
    }

    private async Task<LocalityStateVm?> GetByPredicate(Expression<Func<Locality, bool>> predicate, CancellationToken cancellationToken)
    {
        try
        {
            return await _context
                .Locality
                .Include(loc => loc.State)
                .Where(predicate)
                .Select(loc => new LocalityStateVm(
                    loc.Id, 
                    loc.Name, 
                    loc.IbgeCode, 
                    loc.StateId, 
                    MapState(loc.State)))
                .FirstOrDefaultAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    private static StateVm MapState(State state)
    {
        return new StateVm(
            state.Id,
            state.Name,
            state.Acronym,
            state.IbgeCode
        );
    }
}
