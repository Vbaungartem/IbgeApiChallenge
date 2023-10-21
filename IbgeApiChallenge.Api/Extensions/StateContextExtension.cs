using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Create.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Delete.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.ListAll.Implementations;
using IbgeApiChallenge.Infra.Data;
using MediatR;
using Handler = IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Handler;

namespace IbgeApiChallenge.Api.Extensions;

public static class StateContextExtension
{
    public static void AddStateContext(this WebApplicationBuilder builder)
    {
        #region Create **************************************************

        builder.Services.AddTransient<IStateCreateRepository, StateCreateRepository>();

        #endregion

        #region ListAll ********************************************

        builder.Services.AddTransient<IStateListAllRepository, StateListAllRepository>();

        #endregion
        
        #region Delete ********************************************

        builder.Services.AddTransient<IStateDeleteRepository, StateDeleteRepository>();

        #endregion
    }

    public static void AddStateEndpoints(this WebApplication app)
    {
        #region Create *****************************************
        app.MapPost("api/v1/state/create", handler: async (
            Request request,
            IRequestHandler<Request, Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/state/create/{result.ResponseData?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        }).RequireAuthorization();
        #endregion
        
        #region ListAll *****************************************
        
        app.MapGet("api/v1/state/listAll", handler: async (IStateListAllRepository stateListAllRepository )
            =>
        {
            var request = new Core.Contexts.StateContext.UseCases.ListAll.Request();
            var handler = new Handler(stateListAllRepository);
            var result = await handler.Handle(request, new CancellationToken());
            //var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).RequireAuthorization();
        #endregion
        
        #region Delete *****************************************
        
        app.MapDelete("api/v1/state/{id}/delete", handler: async (string id, IStateDeleteRepository stateDeleteRepository )
            =>
        {
            var request = new Core.Contexts.StateContext.UseCases.Delete.Request();
            var handler = new Core.Contexts.StateContext.UseCases.Delete.Handler(stateDeleteRepository);
            request.Id = id;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).RequireAuthorization();
        #endregion
    }
}