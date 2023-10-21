using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateDeleteRepository _stateDeleteRepository;

    public Handler(IStateDeleteRepository stateDeleteRepository)
    {
        _stateDeleteRepository = stateDeleteRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Verify

        var exists = await _stateDeleteRepository.AnyAsync(request.Id, cancellationToken);
        
        if (!exists)
            return new Response("O estado solicitado não existe ou não foi cadastrado.", status: 400);

        #endregion

        #region Delete Entity Literaly

        try
        { 
            await _stateDeleteRepository.DeleteStateAsync(request.Id, cancellationToken);
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