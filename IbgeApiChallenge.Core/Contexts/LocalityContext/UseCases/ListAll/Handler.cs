using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ViewModels;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityListAllRepository _localityListAllRepository;

    public Handler(ILocalityListAllRepository stateListAllRepository)
    {
        _localityListAllRepository = stateListAllRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        List<LocalityVm> localities;
        try
        {
            if(string.IsNullOrEmpty(request.Name))
            {
                localities = await _localityListAllRepository.ListAllAsync(cancellationToken);

                if (localities is null || localities.Count() is 0)
                    return new Response("Não há nenhuma localidade cadastrado na base de dados", status: 404);
            }
            else
            {
                localities = await _localityListAllRepository.ListAllAsync(request.Name, cancellationToken);

                if (localities is null || localities.Count() is 0)
                    return new Response($"Não há nenhuma localidade com esse nome {request.Name} ou parecido.", status: 404);
            }

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        var responseData = new ResponseData(localities);

        return new Response($"Total de Localidades: {responseData.Localities.Count}", responseData);
    }
}