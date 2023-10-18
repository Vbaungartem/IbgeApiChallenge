using System.Text;
using IbgeApiChallenge.Core;
using IbgeApiChallenge.Infra.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace IbgeApiChallenge.Api.Extensions;

public static class BuilderExtensions
{
    public static void AddConfiguration(this WebApplicationBuilder builder)
    {
        Configuration.DataBase.ConnectionString =
            builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        Configuration.Secrets.ApiKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("ApiKey") ?? string.Empty;
        Configuration.Secrets.JwtPrivateKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("JwtPrivateKey") ?? string.Empty;
        Configuration.Secrets.PasswordSaltKey =
            builder.Configuration.GetSection("Secrets").GetValue<string>("PasswordSaltKey") ?? string.Empty;
        Configuration.Email.DefaultFromEmail =
            builder.Configuration.GetSection("Email").GetValue<string>("DefaultFromEmail") ?? string.Empty;
        Configuration.Email.DefaultFromName = 
            builder.Configuration.GetSection("Email").GetValue<string>("DefaultFromName") ?? string.Empty;
    }

    public static void AddDatabaseConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(db =>
            db.UseSqlServer(
                Configuration.DataBase.ConnectionString, b => b.MigrationsAssembly("IbgeApiChallenge.Api")));
    }

    public static void AddJwtAuthentication(this WebApplicationBuilder builder)
    {
        builder.Services
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.Secrets.JwtPrivateKey)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        builder.Services.AddAuthorization();
    }
    public static void AddMediator(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(x =>
            x.RegisterServicesFromAssembly(typeof(Configuration).Assembly));
    }
}