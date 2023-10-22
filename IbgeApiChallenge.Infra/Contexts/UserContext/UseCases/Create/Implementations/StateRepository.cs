using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.Entities;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Create.Implementations;

public class StateRepository : IStateRepository
{
    private readonly AppDbContext _context;

    public StateRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<State>> ListAllAsync()
    {
        var retorno = await _context.State.ToListAsync();
        return retorno;
    }
}
