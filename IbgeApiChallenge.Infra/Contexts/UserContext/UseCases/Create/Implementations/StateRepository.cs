using IbgeApiChallenge.Core.Contexts.UserContext.Entities;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.Create.Implementations;

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
