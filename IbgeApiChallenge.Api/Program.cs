using IbgeApiChallenge.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabaseConfiguration();
builder.AddMediator();
builder.AddUserContext();
builder.AddJwtAuthentication();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.AddUserEndpoints();


app.Run();
