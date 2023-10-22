using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Get.Implementations;

public class StateGetRepository : IStateGetRepository
{
    private readonly AppDbContext _context;

    public StateGetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<StateVm?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.Id == new Guid(id), cancellationToken);
    }

    public async Task<StateVm?> GetByAcronymAsync(string acronym, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.Acronym== acronym, cancellationToken);
    }

    public async Task<StateVm?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.IbgeCode == ibgeCode, cancellationToken);
    }

    public async Task<StateVm?> GetByNameCodeAsync(string name, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.Name == name, cancellationToken);
    }

  
    private async Task<StateVm?> GetByPredicate(Expression<Func<State,bool>> predicate, CancellationToken cancellationToken)
    {
       return await _context
           .State
           .Where(predicate)
           .Select(state => new StateVm(
               state.Id, 
               state.Name,
               state.Acronym,
               state.IbgeCode))
           .FirstOrDefaultAsync(cancellationToken);
    
    }
}