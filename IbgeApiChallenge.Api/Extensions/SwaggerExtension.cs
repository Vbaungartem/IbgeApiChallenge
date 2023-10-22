using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace IbgeApiChallenge.Api.Extensions
{
    public static class SwaggerExtension
    {
        public static void AddSwagger(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IbgeApiChallenge.Api", Description = "Teste com Minimal APIs", Version = "v1" });
                c.CustomSchemaIds(type => type.FullName);

                // Adicionar a autenticação JWT
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Por favor, insira o token JWT com 'Bearer ' na frente. Exemplo: Bearer {token}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void AddSwaggerEndpoints(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Início v1");

                // Habilitar o botão de autorização para usar o token
                c.OAuthUsePkce();
            });
        }
    }
}
