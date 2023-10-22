using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Delete.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Get.Interfaces;
using IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.ListAll.Interfaces;
using IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.Create.Implementations;
using IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.Delete.Implementations;
using IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.Get.Implementations;
using IbgeApiChallenge.Infra.Contexts.LocalityContext.UseCases.ListAll.Implementations;
using MediatR;
using Request = IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create.Request;
using Response = IbgeApiChallenge.Core.Contexts.LocalityContext.UseCases.Create.Response;

namespace IbgeApiChallenge.Api.Extensions;

public static class LocalityContextExtension
{
    public static void AddLocalityContext(this WebApplicationBuilder builder)
    {
        #region Create **************************************************

        builder.Services.AddTransient<ILocalityCreateRepository, LocalityCreateRepository>();

        #endregion

        #region Get By Filter *****************************************

        builder.Services.AddTransient<ILocalityGetRepository, LocalityGetRepository>();

        #endregion

        #region ListAll ********************************************

        builder.Services.AddTransient<ILocalityListAllRepository, LocalityListAllRepository>();

        #endregion

        #region Delete ********************************************

        builder.Services.AddTransient<ILocalityDeleteRepository, LocalityDeleteRepository>();

        #endregion
    }

    public static void AddLocalityEndpoints(this WebApplication app)
    {
        #region Create *****************************************
        app.MapPost("api/v1/locality/create", handler: async (
            Request request,
            IRequestHandler<Request, Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/locality/create/{result.ResponseData?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        }).WithTags("Locality").RequireAuthorization();
        #endregion

        #region Get By Filter *****************************************

        app.MapGet("api/v1/locality/{id}/id", handler: async (string id, ILocalityGetRepository localityGetRepository)
            =>
        {
            var request = new Core.Contexts.LocalityContext.UseCases.Get.Request();
            var handler = new Core.Contexts.LocalityContext.UseCases.Get.Handler(localityGetRepository);
            request.Filter = id;
            request.Type = TypeEnum.Id;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("Locality").RequireAuthorization();

        app.MapGet("api/v1/locality/{ibgeCode}/ibgeCode", handler: async (string ibgeCode, ILocalityGetRepository localityGetRepository)
            =>
        {
            var request = new Core.Contexts.LocalityContext.UseCases.Get.Request();
            var handler = new Core.Contexts.LocalityContext.UseCases.Get.Handler(localityGetRepository);
            request.Filter = ibgeCode;
            request.Type = TypeEnum.IbgeCode;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("Locality").RequireAuthorization();

        app.MapGet("api/v1/locality/{name}/name", handler: async (string name, ILocalityGetRepository localityGetRepository)
            =>
        {
            var request = new Core.Contexts.LocalityContext.UseCases.Get.Request();
            var handler = new Core.Contexts.LocalityContext.UseCases.Get.Handler(localityGetRepository);
            request.Filter = name;
            request.Type = TypeEnum.Name;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("Locality").RequireAuthorization();
        #endregion

        #region ListAll *****************************************

        app.MapGet("api/v1/locality/listAll", handler: async (ILocalityListAllRepository LocalityListAllRepository)
            =>
        {
            var request = new Core.Contexts.LocalityContext.UseCases.ListAll.Request();
            var handler = new Core.Contexts.LocalityContext.UseCases.ListAll.Handler(LocalityListAllRepository);
            var result = await handler.Handle(request, new CancellationToken());
            //var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("Locality").RequireAuthorization();

        #endregion

        #region Delete *****************************************

        app.MapDelete("api/v1/locality/{id}/delete", handler: async (string id, ILocalityDeleteRepository LocalityDeleteRepository)
            =>
        {
            var request = new Core.Contexts.LocalityContext.UseCases.Delete.Request();
            var handler = new Core.Contexts.LocalityContext.UseCases.Delete.Handler(LocalityDeleteRepository);
            request.Id = id;
            var result = await handler.Handle(request, new CancellationToken());
            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            return Results.Json(result);

        }).WithTags("Locality").RequireAuthorization();

        #endregion
    }
}
