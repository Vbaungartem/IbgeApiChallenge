using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateName.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateName;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateUpdateNameRepository _stateUpdateNameRepository;

    public Handler(IStateUpdateNameRepository stateUpdateNameRepository)
    {
        _stateUpdateNameRepository = stateUpdateNameRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Assert Request

        try
        {
            var res = Specifications.Assert(request);
            if (!res.IsValid)
                return new Response("Requisição inválida.", status: 400, res.Notifications);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível realizar sua requisição por um erro interno: \n{e.Message}",
                status: 500);
        }
        #endregion
        #region Generate Object and check existence
        
        State? state;
        try
        {
            state = await _stateUpdateNameRepository.GetByIdAsync(request.Id, cancellationToken);
            if(state is null)
                return new Response("O Estado solicitado não foi econtrado.", status: 404);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o Estado solicitado por um erro interno: \n{e.Message}",
                status: 500);
        }
        #endregion
        #region Update Name Entity
        try
        { 
            state.UpdateName(request.Name);
            await _stateUpdateNameRepository.UpdateAndSaveStateAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o Estado solicitado por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        #endregion
        #region Prepare and return success

        var responseData = new ResponseData(
            request.Id, 
            state.Name, 
            state.IbgeCode, 
            state.Acronym);
        
        return new Response($"O nome do Estado {state.Name} foi atualizado com sucesso.", responseData);

        #endregion
    }
}