using System.Globalization;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Delete.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateAcronym.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Interfaces;
using IbgeApiChallenge.Core.Contexts.StateContext.UseCases.UpdateName.Interfaces;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Create.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Delete.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Get.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.ListAll.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.Update.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.UpdateAcronym.Implementations;
using IbgeApiChallenge.Infra.Contexts.StateContext.UseCases.UpdateIbgeCode.Implementations;
using MediatR;
using Handler = IbgeApiChallenge.Core.Contexts.StateContext.UseCases.ListAll.Handler;
using Request = IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Request;
using Response = IbgeApiChallenge.Core.Contexts.StateContext.UseCases.Create.Response;

namespace IbgeApiChallenge.Api.Extensions;

public static class StateContextExtension
{
    public static void AddStateContext(this WebApplicationBuilder builder)
    {
        #region Create **************************************************

        builder.Services.AddTransient<IStateCreateRepository, StateCreateRepository>();

        #endregion
        #region Get By Filter *******************************************
        builder.Services.AddTransient<IStateGetRepository, StateGetRepository>();
        #endregion
        #region ListAll *************************************************

        builder.Services.AddTransient<IStateListAllRepository, StateListAllRepository>();

        #endregion
        #region Delete **************************************************

        builder.Services.AddTransient<IStateDeleteRepository, StateDeleteRepository>();

        #endregion
        #region Update Name *********************************************

        builder.Services.AddTransient<IStateUpdateNameRepository, StateUpdateNameRepository>();

        #endregion
        #region Update Acronym ******************************************

        builder.Services.AddTransient<IStateUpdateAcronymRepository, StateUpdateAcronymRepository>();

        #endregion
        #region Update IbgeCode *****************************************

        builder.Services.AddTransient<IStateUpdateIbgeCodeRepository, StateUpdateIbgeCodeRepository>();

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
        }).WithTags("State").RequireAuthorization();
        #endregion
        #region Get By Filter **********************************

        app.MapGet("api/v1/state/{id}/id", handler: async (string id, IStateGetRepository stateGetRepository)
            =>
        {
            var request = new Core.Contexts.StateContext.UseCases.Get.Request();
            var handler = new Core.Contexts.StateContext.UseCases.Get.Handler(stateGetRepository);
            request.Filter = id;
            request.Type = TypeEnum.Id;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("State").RequireAuthorization();

        app.MapGet("api/v1/state/{acronym}/acronym", handler: async (string acronym, IStateGetRepository stateGetRepository)
            =>
        {
            var request = new Core.Contexts.StateContext.UseCases.Get.Request();
            var handler = new Core.Contexts.StateContext.UseCases.Get.Handler(stateGetRepository);
            request.Filter = acronym;
            request.Type = TypeEnum.Acronym;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("State").RequireAuthorization();

        app.MapGet("api/v1/state/{ibgeCode}/ibgeCode", handler: async (string ibgeCode, IStateGetRepository stateGetRepository)
            =>
        {
            var request = new Core.Contexts.StateContext.UseCases.Get.Request();
            var handler = new Core.Contexts.StateContext.UseCases.Get.Handler(stateGetRepository);
            request.Filter = ibgeCode;
            request.Type = TypeEnum.IbgeCode;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("State").RequireAuthorization();

        app.MapGet("api/v1/state/{name}/name", handler: async (string name, IStateGetRepository stateGetRepository)
            =>
        {
            var request = new Core.Contexts.StateContext.UseCases.Get.Request();
            var handler = new Core.Contexts.StateContext.UseCases.Get.Handler(stateGetRepository);
            request.Filter = name;
            request.Type = TypeEnum.Name;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("State").RequireAuthorization();
        #endregion
        #region ListAll ****************************************

        app.MapGet("api/v1/state/listAll", handler: async (IStateListAllRepository stateListAllRepository)
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

        }).WithTags("State").RequireAuthorization();
        #endregion
        #region Delete *****************************************

        app.MapDelete("api/v1/state/{id}/delete", handler: async (string id, IStateDeleteRepository stateDeleteRepository)
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

        }).WithTags("State").RequireAuthorization();
        #endregion
        #region Update Name ************************************

        app.MapPut("api/v1/state/{id}/update/name", handler: async ( string id,
            Core.Contexts.StateContext.UseCases.UpdateName.Request request,
            IRequestHandler<
                Core.Contexts.StateContext.UseCases.UpdateName.Request, 
                Core.Contexts.StateContext.UseCases.UpdateName.Response> handler) =>
        {
            request.Id = id;
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        }).WithTags("State").RequireAuthorization();

        #endregion
        #region Update Acronym *********************************

        app.MapPut("api/v1/state/{id}/update/acronym", handler: async ( string id,
            Core.Contexts.StateContext.UseCases.UpdateAcronym.Request request,
            IRequestHandler<
                Core.Contexts.StateContext.UseCases.UpdateAcronym.Request, 
                Core.Contexts.StateContext.UseCases.UpdateAcronym.Response> handler) =>
        {
            request.Id = id;
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        }).WithTags("State").RequireAuthorization();

        #endregion
        #region Update IbgeCode ********************************

        app.MapPut("api/v1/state/{id}/update/IbgeCode", handler: async ( string id,
            Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Request request,
            IRequestHandler<
                Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Request, 
                Core.Contexts.StateContext.UseCases.UpdateIbgeCode.Response> handler) =>
        {
            request.Id = id;
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Ok(result)
                : Results.Json(result, statusCode: result.Status);
        }).WithTags("State").RequireAuthorization();

        #endregion
    }
}