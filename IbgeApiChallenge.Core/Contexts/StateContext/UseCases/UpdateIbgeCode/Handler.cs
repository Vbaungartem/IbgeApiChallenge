using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateIbgeCode;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateUpdateIbgeCodeRepository _stateUpdateIbgeCodeRepository;

    public Handler(IStateUpdateIbgeCodeRepository stateUpdateIbgeCodeRepository)
    {
        _stateUpdateIbgeCodeRepository = stateUpdateIbgeCodeRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Assert by ValueObject and Generete Objects

        IbgeCode ibgeCode;
        State? state;
        
        try
        {
            ibgeCode = new IbgeCode(request.IbgeCode);
            if(!ibgeCode.IsValid)
                return new Response("Código do IBGE inválido.", status: 400, ibgeCode.Notifications);

            state = await _stateUpdateIbgeCodeRepository.GetByIdAsync(request.Id, cancellationToken);

            if (state is null)
                return new Response("Estado não encontrado.", status: 404);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o Estado solicitado por um erro interno: \n{e.Message}",
                status: 500);
        }
        #endregion
        #region UpdateModel

        try
        {
            state.UpdateIbgeCode(ibgeCode.Code);
            await _stateUpdateIbgeCodeRepository.UpdateLocalityChildrenWithNewStateIbgePrefixAsync(
                state.Id,
                state.IbgeCode, 
                cancellationToken);
            
            await _stateUpdateIbgeCodeRepository.UpdateAndSaveAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o Estado solicitado por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        #endregion

        #region Prepare And return Response

        ResponseData responseData =
            new ResponseData(state.Id.ToString(), state.Name, state.IbgeCode, state.Acronym);
        
        return new Response($"Código do IBGE do estado {state.Name} e suas localidades filhas foram atualizados com sucesso.", responseData);
        #endregion
    }
}