using IbgeApiChallenge.Api.Extensions;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabaseConfiguration();
builder.AddMediator();
builder.AddUserContext();
builder.AddSwagger();
builder.AddJwtAuthentication();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//Apenas para teste
app.MapGet("/", () => "Hello World!");

app.AddSwaggerEndpoints();
app.AddUserEndpoints();


app.Run();
