using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.UpdateIbgeCode.Implementations;

public class StateUpdateIbgeCodeRepository : IStateUpdateIbgeCodeRepository
{
    private readonly AppDbContext _context;

    public StateUpdateIbgeCodeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<State?> GetByIdAsync(string requestId, CancellationToken cancellationToken)
        => await _context.State
            .FirstOrDefaultAsync(state => state.Id.ToString() == requestId, cancellationToken);

    public async Task UpdateAndSaveAsync(CancellationToken cancellationToken)
        => await _context.SaveChangesAsync(cancellationToken);

    public async Task UpdateLocalityChildrenWithNewStateIbgePrefixAsync(Guid stateId, string ibgeCode,
        CancellationToken cancellationToken)
    {
        var localities = await _context.Locality.Where(loc => loc.StateId == stateId).ToListAsync(cancellationToken);

        foreach (var locality in localities)
        {
            var code = locality.IbgeCode;
            var newCode = ibgeCode + code.Substring(2);
            locality.UpdateIbgeCode(newCode);
        }
    }
}