using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateGetRepository _stateGetRepository;

    public Handler(IStateGetRepository stateGetRepository)
    {
        _stateGetRepository = stateGetRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

        #region Verify type

        State? state;
        try
        {

            switch (request.Type)
            {
                case 0:
                    state = await _stateGetRepository.GetByIdAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com id na base de dados", status: 404);
                    break;
                case 1:
                    state = await _stateGetRepository.GetByAcronymAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com essa sigla na base de dados", status: 404);
                    break;
                case 2:
                    state = await _stateGetRepository.GetByIbgeCodeAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com esse código IBGE na base de dados", status: 404);
                    break;
                case 3:
                    state = await _stateGetRepository.GetByNameCodeAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com esse nome na base de dados", status: 404);
                    break;
                default:
                    return new Response("Tipo de solitação não suportada.", status: 501);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        var responseData = new ResponseData(state);

        return new Response($"Estado localizado com sucesso.", responseData);

        #endregion

    }
}