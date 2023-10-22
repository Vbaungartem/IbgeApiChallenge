using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Get.Implementations;

public class StateGetRepository : IStateGetRepository
{
    private readonly AppDbContext _context;

    public StateGetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<State?> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.Id == new Guid(id), cancellationToken);
    }

    public async Task<State?> GetByAcronymAsync(string acronym, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.Acronym== acronym, cancellationToken);
    }

    public async Task<State?> GetByIbgeCodeAsync(string ibgeCode, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.IbgeCode == ibgeCode, cancellationToken);
    }

    public async Task<State?> GetByNameCodeAsync(string name, CancellationToken cancellationToken)
    {
        return await GetByPredicate(state => state.Name == name, cancellationToken);
    }

  
    private async Task<State?> GetByPredicate(Expression<Func<State,bool>> predicado, CancellationToken cancellationToken)
    {
        try
        {
           return await _context.State.FirstOrDefaultAsync(predicado, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}