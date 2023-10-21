using IbgeApiChallenge.Core.Contexts.StateContext.Entitties;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;
using MediatR;

namespace IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll;

public class Handler : IRequestHandler<Request, Response>
{
    private readonly IStateListAllRepository _stateListAllRepository;
    
    public Handler(IStateListAllRepository stateListAllRepository)
    {
        _stateListAllRepository = stateListAllRepository;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        List<State> states;
        try
        {
            states = await _stateListAllRepository.ListAllAsync(cancellationToken);

            if (states is null || states.Count() is 0)
                return new Response("Não há nenhum Estado cadastrado na base de dados", status: 404);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        var responseData = new ResponseData(states);

        return new Response($"Total de estados: {responseData.States.Count}", responseData);
    }
}