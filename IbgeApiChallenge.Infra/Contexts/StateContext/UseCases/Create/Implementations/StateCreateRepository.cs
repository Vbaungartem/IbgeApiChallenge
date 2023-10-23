using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Create.Implementations;

public class StateCreateRepository : IStateCreateRepository
{
    private readonly AppDbContext _context;

    public StateCreateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<bool> AnyAsync(string requestIbgeCode, string requestAcronym, CancellationToken cancellationToken)
        => await _context.State.AnyAsync(state => 
            state.IbgeCode == requestIbgeCode || 
            state.Acronym == requestAcronym, cancellationToken);

    public async Task AppendAndSaveAsync(State state, CancellationToken cancellationToken)
    {
        await _context.State.AddAsync(state, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }
}