using IbgeApiChallenge.Core.Contexts.LocalityContext.Entities;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateIbgeCode.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ValueObjects;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.UpdateIbgeCode;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityUpdateIbgeCodeRepository _localityUpdateIbgeCodeRepository;

    public Handler(ILocalityUpdateIbgeCodeRepository localityUpdateIbgeCodeRepository)
    {
        _localityUpdateIbgeCodeRepository = localityUpdateIbgeCodeRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        #region Assert by ValueObject and Generate Object

        IbgeCode ibgeCode;
        Locality? locality;
        try
        {
            locality = await _localityUpdateIbgeCodeRepository.GetByIdAsync(request.Id, cancellationToken);
            
            if(locality is null)
                return new Response("Localidade não encontrada na base de dados.", status: 404);
            
            if(locality.IbgeCode.Substring(0, 2) != request.IbgeCode.Substring(0, 2))
                return new Response("Não é possível atualizar o código do IBGE alterando o prefixo de Estado, caso seja necessário, atualize o Id do estado da localdiade.", status: 400);
            
            locality.UpdateIbgeCodeWithoutSufixChanges(request.IbgeCode);
            ibgeCode = new IbgeCode(locality.IbgeCode);
            if (!ibgeCode.IsValid)
                return new Response("O código do IBGE da localidade é inválido.", status: 400,
                    ibgeCode.Notifications);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o código do IBGE da localidade solicitada por um erro interno: \n{e.Message}",
                status: 500);
        }
        #endregion

        #region Update entity

        try
        {
            await _localityUpdateIbgeCodeRepository.UpdateAndSaveAsync(cancellationToken);
        }
        catch (Exception e)
        {
            return new Response($"Não foi possível atualizar o código do IBGE da localidade solicitada por um erro interno: \n{e.Message}",
                status: 500);
        }
        #endregion

        #region Prepare and return Response Data

        ResponseData responseData = new ResponseData(locality.Id.ToString(), locality.Name, locality.IbgeCode);

        return new Response("Código do IBGE atualizado com sucesso.", responseData);

        #endregion
    }
}