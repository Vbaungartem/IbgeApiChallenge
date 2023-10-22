using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;
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

        StateVm? state;
        try
        {
            switch (request.Type)
            {
                case TypeEnum.Id:
                    state = await _stateGetRepository.GetByIdAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com id na base de dados", status: 404);
                    break;
                case TypeEnum.Acronym:
                    state = await _stateGetRepository.GetByAcronymAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com essa sigla na base de dados", status: 404);
                    break;
                case TypeEnum.IbgeCode:
                    state = await _stateGetRepository.GetByIbgeCodeAsync(request.Filter, cancellationToken);
                    if (state is null)
                        return new Response("Não há nenhum Estado com esse código IBGE na base de dados", status: 404);
                    break;
                case TypeEnum.Name:
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

        return new Response($"Estado {responseData.State.Name} localizado com sucesso.", responseData);

        #endregion

    }
}