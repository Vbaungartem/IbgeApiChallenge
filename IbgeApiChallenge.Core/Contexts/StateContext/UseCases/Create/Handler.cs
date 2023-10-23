using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.ValueObjects;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateCreateRepository _stateCreateRepository;

    public Handler(IStateCreateRepository stateCreateRepository)
    {
        _stateCreateRepository = stateCreateRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region 01. Assert request ************************************************

        var res = await Specifications.Assert(request);
        if (!res.IsValid)
            return new Response("Requisição inválida.", status: 400, notifications: res.Notifications);

        #endregion

        #region 02. Generate Objects and Check Duality ************************************************

        IbgeCode ibgeCode;
        Acronym acronym;
        State state;
        
        try
        {
            ibgeCode = new IbgeCode(request.IbgeCode);
            acronym = new Acronym(request.Acronym);
            
            if(!acronym.IsValid)
                return new Response("Sigla do estado inválida.", status: 400, acronym.Notifications);
            if (!ibgeCode.IsValid)
                return new Response("Código do IBGE inválido.", status: 400, ibgeCode.Notifications);
            
            
            state = new State(ibgeCode.Code, request.Name, acronym.AcronymText);
            var exists = await _stateCreateRepository.AnyAsync(request.IbgeCode, acronym.AcronymText, cancellationToken);
            
            if (exists)
                return new Response("O código do IBGE ou o Acrônimo inserido já existe registrado na base de dados.", status: 400);

        }
        catch (Exception e)
        {
            return new Response($"Não foi possível cadastrar o estado solicitado por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }

        #endregion

        #region 03. Register Data ************************************************

        try
        {
            await _stateCreateRepository.AppendAndSaveAsync(state, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        #endregion

        #region 04. Return Response **********************************************

        var responseData = new ResponseData(state.Id, state.IbgeCode, state.Name, state.Acronym);
        return new Response("Estado registrado com sucesso!", responseData);

        #endregion
    }
}