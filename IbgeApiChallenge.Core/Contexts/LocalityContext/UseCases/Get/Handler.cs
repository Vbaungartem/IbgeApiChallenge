using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityGetRepository _localityGetRepository;

    public Handler(ILocalityGetRepository localityGetRepository)
    {
        _localityGetRepository = localityGetRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {

        #region Verify type

        LocalityStateVm? locality;
        try
        {

            switch (request.Type)
            {
                case TypeEnum.Id:
                    locality = await _localityGetRepository.GetByIdAsync(request.Filter, cancellationToken);
                    if (locality is null)
                        return new Response("Não há nenhum Localidade com id na base de dados", status: 404);
                    break;
                case TypeEnum.IbgeCode:
                    locality = await _localityGetRepository.GetByIbgeCodeAsync(request.Filter, cancellationToken);
                    if (locality is null)
                        return new Response("Não há nenhum Localidade com esse código IBGE na base de dados", status: 404);
                    break;
                case TypeEnum.Name:
                    locality = await _localityGetRepository.GetByNameCodeAsync(request.Filter, cancellationToken);
                    if (locality is null)
                        return new Response("Não há nenhum Localidade com esse nome na base de dados", status: 404);
                    break;
                default:
                    return new Response("Tipo de solitação não suportada.", status: 501);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        var responseData = new ResponseData(locality);

        return new Response($"Localidade {responseData.locality.Name} encontrada com sucesso.", responseData);

        #endregion

    }
}