using IbgeApiChallenge.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddConfiguration();
builder.AddDatabaseConfiguration();
builder.AddMediator();
builder.AddUserContext();
builder.AddStateContext();
builder.AddLocalityContext();
builder.AddSwagger();

builder.AddJwtAuthentication();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.AddSwaggerEndpoints();
app.AddUserEndpoints();
app.AddStateEndpoints();
app.AddLocalityEndpoints();

app.Run();
