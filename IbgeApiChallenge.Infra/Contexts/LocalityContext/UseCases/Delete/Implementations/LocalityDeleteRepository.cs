using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete.Interfaces;
using IbgeApiChallenge.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.Delete.Implementations;

public class LocalityDeleteRepository : ILocalityDeleteRepository
{
    private readonly AppDbContext _context;

    public LocalityDeleteRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<bool> AnyAsync(string requestId, CancellationToken cancellationToken)
        => await _context.Locality
                    .AnyAsync(locality => locality.Id.ToString() == requestId, cancellationToken);

    public async Task DeleteLocalityAsync(string requestId, CancellationToken cancellationToken)
    {
        var locality = await _context.Locality.FirstOrDefaultAsync(locality => locality.Id.ToString() == requestId, cancellationToken);
        try
        {
            _context.Locality.Remove(locality);
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

}
