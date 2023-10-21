using Microsoft.OpenApi.Models;

namespace IbgeApiChallenge.Api.Extensions;

public static class SwaggerExtension
{
    public static void AddSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "APISaudacao", Description = "Teste com Minimal APIs", Version = "v1" });
        });
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