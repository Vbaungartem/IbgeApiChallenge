using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateName.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateName;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityUpdateNameRepository _localityUpdateNameRepository;

    public Handler(ILocalityUpdateNameRepository localityUpdateNameRepository)
    {
        _localityUpdateNameRepository = localityUpdateNameRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Assert Request

        try
        {
            var res = await Specifications.Assert(request, cancellationToken);
            if (!res.IsValid)
                return new Response("A requisição é inválida.", status: 400, res.Notifications);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o nome da localidade solicitada por um erro interno: \n{e.Message}",
                status: 500);
        }

        #endregion
        #region Genereate Objects and Verify Existance

        Locality? locality;
        try
        {
            locality = await _localityUpdateNameRepository.GetByIdAsync(request.Id, cancellationToken);
            if (locality is null)
                return new Response("Localidade não encontrada na base de dados.", status: 404);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o nome da localidade solicitada por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        
        #endregion

        #region Update Entity
        try
        {
            locality.UpdateName(request.Name);
            await _localityUpdateNameRepository.UpdateAndSaveAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar a localidade solicitada por um erro de repositório interno: \n{e.Message}",
                status: 500);
        }
        ResponseData responseData = 
            new ResponseData(
                locality.Id.ToString(), 
                locality.Name, 
                locality.IbgeCode);

        return new Response("Nome da Localidade atualizada com sucesso.", responseData);
        #endregion
    }
}