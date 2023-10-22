using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.ListAll.Implementations;

public class StateListAllRepository : IStateListAllRepository
{
    private readonly AppDbContext _context;

    public StateListAllRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<StateVm>?> ListAllAsync(CancellationToken cancellationToken)
    {
        return await _context.State
            .AsNoTracking()
            .Select(state => new StateVm(
                state.Id, 
                state.Name,
                state.Acronym,
                state.IbgeCode))
            .ToListAsync(cancellationToken: cancellationToken);
    }
}