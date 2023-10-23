using IbgeApiChallenge.Core.Contexts.LocalityContext.Entitties;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.ValueObjects;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly ILocalityCreateRepository _localityCreateRepository;

    public Handler(ILocalityCreateRepository localityCreateRepository)
    {
        _localityCreateRepository = localityCreateRepository;
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
        Locality locality;

        try
        {
            ibgeCode = new IbgeCode(request.IbgeCode);

            if (!ibgeCode.IsValid)
                return new Response("O código do IBGE da localidade é inválido.", status: 400, ibgeCode.Notifications);
            
            locality = new Locality(ibgeCode.Code, request.Name, request.StateId);
            
            var exists = await _localityCreateRepository.AnyAsync(request.IbgeCode, cancellationToken);


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
            await _localityCreateRepository.AppendAndSaveAsync(locality, cancellationToken);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        #endregion

        #region 04. Return Response **********************************************

        var responseData = new ResponseData(locality.Id, locality.IbgeCode, locality.Name, locality.StateId.ToString());
        return new Response("Localidade registrado com sucesso!", responseData);

        #endregion
    }
}
