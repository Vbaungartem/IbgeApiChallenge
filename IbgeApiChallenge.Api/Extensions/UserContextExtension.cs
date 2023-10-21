using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Interfaces;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create.Interfaces;
using IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.Authenticate.Implementations;
using IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.Create.Implementations;
using MediatR;

namespace IbgeApiChallenge.Api.Extensions;

public static class UserContextExtension
{
    public static void AddUserContext(this WebApplicationBuilder builder)
    {
        #region Create **************************************************

        builder.Services.AddTransient<IUserCreateRepository, UserCreateRepository>();

        #endregion

        #region Authenticate ********************************************

        builder.Services.AddTransient<IUserAuthenticateRepository, UserAuthenticateRepository>();

        #endregion

    }

    public static void AddUserEndpoints(this WebApplication app)
    {
        #region Create *****************************************
        app.MapPost("api/v1/user/create", handler: async (
            Request request,
            IRequestHandler<Request, Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            return result.IsSuccess
                ? Results.Created($"api/v1/user/create/{result.ResponseData?.Id}", result)
                : Results.Json(result, statusCode: result.Status);
        });
        #endregion

        #region Authenticate ***************************

        app.MapPost("api/v1/user/authenticate", handler: async (
            IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Request request,
            IRequestHandler<
                IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Request, 
                IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Authenticate.Response> handler) =>
        {
            var result = await handler.Handle(request, new CancellationToken());

            if (!result.IsSuccess)
                return Results.Json(result, statusCode: result.Status);

            if (result.ResponseData is null)
                return Results.Json(result, statusCode: 500);

            result.ResponseData.SetToken(
                JwtExtension.Generate(result.ResponseData)
                );
            return Results.Ok(result);
        });
        #endregion
    }

    public static void AddSwaggerEndpoints(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Início v1");
        });
    }
}