using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateAcronym.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateAcronym;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateUpdateAcronymRepository _stateUpdateAcronymRepository;

    public Handler(IStateUpdateAcronymRepository stateUpdateAcronymRepository)
    {
        _stateUpdateAcronymRepository = stateUpdateAcronymRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Assert by ValueObject and Generate Objects

        Acronym acronym;
        State? state;

        try
        {
            acronym = new Acronym(request.Acronym);
            if (!acronym.IsValid)
                return new Response("A sigla do Estado não é válida.", status: 400, acronym.Notifications);
            
            state = await _stateUpdateAcronymRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if(state is null)
                return new Response("O Estado solicitado não foi econtrado.", status: 404);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o Estado solicitado por um erro interno: \n{e.Message}",
                status: 500);
        }
        #endregion
        #region Update State Acronym
        try
        {
            state.UpdateAcronym(acronym.AcronymText);
            await _stateUpdateAcronymRepository.UpdateAndSaveAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o Estado solicitado por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        #endregion

        #region Prepare and return Response

        ResponseData responseData = new ResponseData(
            state.Id.ToString(), 
            state.Name, 
            state.IbgeCode,
            state.Acronym);

        return new Response($"Sigla do estado {state.Name} atualizada com sucesso.", responseData);
        #endregion
    }
}