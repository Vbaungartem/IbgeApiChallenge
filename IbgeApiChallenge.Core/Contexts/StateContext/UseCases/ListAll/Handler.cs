﻿using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.VisualModels;
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
        List<StateVm>? states;
        try
        {
            if(string.IsNullOrEmpty( request.Name))
            {
              states = await _stateListAllRepository.ListAllAsync(cancellationToken);

              if (states is null || states.Count() is 0)
                  return new Response("Não há nenhum Estado cadastrado na base de dados", status: 404);
            }
            else
            {
              states = await _stateListAllRepository.ListAllAsync(request.Name, cancellationToken);

              if (states is null || states.Count() is 0)
                  return new Response($"Não há nenhum Estado com esso nome {request.Name} ou parecido.", status: 404);
            }
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }

        var responseData = new ResponseData(states);
        return new Response($"Total de estados: {responseData.States.Count}", responseData);
    }
}