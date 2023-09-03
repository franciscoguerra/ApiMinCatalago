using ApiMinCatalago.ApiEndpoints;
using ApiMinCatalago.AppServicesExtensions;

var builder = WebApplication.CreateBuilder(args);


builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAutenticationJwt();


builder.Services.AddAuthorization();

var app = builder.Build();
app.MapAutenticacaoEndpoint();
app.MapCategoriasEndpoints();
app.MapProdutosEndpoints();

var environment = app.Environment;
app.UseExceptionHandling(environment)
        .UseSwaggerMiddleware()
        .UserAppCors();



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.Run();

