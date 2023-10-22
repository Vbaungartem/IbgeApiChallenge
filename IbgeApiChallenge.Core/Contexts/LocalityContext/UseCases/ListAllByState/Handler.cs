using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAllByState.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAllByState;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityListAllByStateRepository _localityListAllByStateRepository;

    public Handler(ILocalityListAllByStateRepository stateListAllByStateRepository)
    {
        _localityListAllByStateRepository = stateListAllByStateRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

       #region Verify type

        List<LocalityVm> localities;

        try
        {
            switch (request.Type)
            {
              case TypeEnum.Id:
                  localities = await _localityListAllByStateRepository.ListAllByIdStateAsync(request.Filter, cancellationToken);
                  if (localities is null)
                      return new Response($"Não há nenhuma Localidade pertecente ao id {request.Filter} desse estado", status: 404);
              break;
              case TypeEnum.IbgeCode:
                  localities = await _localityListAllByStateRepository.ListAllByIbgeCodeStateAsync(request.Filter, cancellationToken);
                  if (localities is null)
                      return new Response($"Não há nenhuma Localidade pertecente a esse código IBGE {request.Filter} desse estado", status: 404);
              break;
              case TypeEnum.Name:
                localities = await _localityListAllByStateRepository.ListAllByNameStateAsync(request.Filter, cancellationToken);
                if (localities is null)
                    return new Response($"Não há nenhuma Localidade pertecente a esse estado {request.Filter}", status: 404);
              break;

              case TypeEnum.Acronym:
                localities = await _localityListAllByStateRepository.ListAllByAcronymStateAsync(request.Filter, cancellationToken);
                if (localities is null)
                    return new Response($"Não há nenhuma Localidade pertecente a essa sigla {request.Filter} desse estado", status: 404);
              break;
           
              default:
                  return new Response("Tipo de solitação não suportada.", status: 501);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        var responseData = new ResponseData(localities);
        return new Response($"Total de Localidades encontradas: {responseData.Localities.Count}", responseData);

        #endregion
    }
}