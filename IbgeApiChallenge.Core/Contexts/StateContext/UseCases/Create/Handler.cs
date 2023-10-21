using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;
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

        State state;

        try
        {
            state = new State(request.IbgeCode, request.Name, request.Acronym);
            var exists = await _stateCreateRepository.AnyAsync(request.IbgeCode, cancellationToken);


            if (exists)
                return new Response("O código do IBGE já existe registrado na base de dados.", status: 400);

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
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