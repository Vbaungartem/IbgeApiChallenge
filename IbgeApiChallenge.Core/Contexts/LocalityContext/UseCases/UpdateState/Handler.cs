using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateState.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateState;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityUpdateStateRepository _localityUpdateStateRepository;

    public Handler(ILocalityUpdateStateRepository localityUpdateStateRepository)
    {
        _localityUpdateStateRepository = localityUpdateStateRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Generate Objects and verify Existence

        Locality? locality;
        State? state;

        try
        {
            locality = await _localityUpdateStateRepository.GetLocalityByIdAsync(request.Id, cancellationToken);
            
            if(locality is null)
                return new Response("Localidade não encontrada na base de dados.", status: 404);
            
            state = await _localityUpdateStateRepository.GetStateByIdAsync(request.StateId, cancellationToken);
            
            if(state is null)
                return new Response("Estado não encontrado na base de dados.", status: 404);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o nome da localidade solicitada por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        #endregion

        #region Update Entity
        
        try
        {
            var ibgeCodeWithoutPrefix = locality.IbgeCode.Substring(2, 5);
            var newStatePrefixIbgeCode = state.IbgeCode;
            var newIbgeCode = newStatePrefixIbgeCode + ibgeCodeWithoutPrefix;
            
            locality.UpdateIbgeCode(newIbgeCode);
            locality.UpdateStateId(state.Id);

            await _localityUpdateStateRepository.UpdateAndSaveAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o nome da localidade solicitada por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        #endregion

        #region Prepare and return ResponseData

        ResponseData responseData =
            new ResponseData(
                locality.Id.ToString(), 
                locality.Name, 
                locality.IbgeCode, 
                locality.StateId.ToString());

        return new Response("Id do Estado e prefixo do código do IBGE da cidade atualizados com sucesso!",
            responseData);

        #endregion
    }
}