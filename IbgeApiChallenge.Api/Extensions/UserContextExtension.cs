using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Create;
using IbgeApiChallenge.Core.Contexts.UserContext.UseCases.Interfaces;
using IbgeApiChallenge.Infra.Contexts.UserContext.UseCases.Create.Implementations;
using MediatR;

namespace IbgeApiChallenge.Api.Extensions;

public static class UserContextExtension
{
    public static void AddUserContext(this WebApplicationBuilder builder)
    {
        #region Create **************************************************

        builder.Services.AddTransient<IUserRepository, UserRepository>();

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
    }
}