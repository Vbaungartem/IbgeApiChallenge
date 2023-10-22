using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityDeleteRepository _localityDeleteRepository;

    public Handler(ILocalityDeleteRepository localityDeleteRepository)
    {
        _localityDeleteRepository = localityDeleteRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Verify

        var exists = await _localityDeleteRepository.AnyAsync(request.Id, cancellationToken);

        if (!exists)
            return new Response("O estado solicitado não existe ou não foi cadastrado.", status: 400);

        #endregion

        #region Delete Entity Literaly

        try
        {
            await _localityDeleteRepository.DeleteLocalityAsync(request.Id, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        ResponseData responseData = new ResponseData(request.Id);
        return new Response("O estado foi apagado da base de dados.", responseData);

        #endregion
    }
}