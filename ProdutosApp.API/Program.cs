using ProdutosApp.API.Extensions;
using ProdutosApp.API.Middlewares;
using ProdutosApp.Application.Extensions;
using ProdutosApp.Domain.Extensions;
using ProdutosApp.Infra.Data.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Registrando os serviços de injeção de dependência
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddEntityFramework(builder.Configuration);

//Política de autenticação
builder.Services.AddJwtBearerConfig(builder.Configuration);

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configurações para Azure (somente para produção)
if (builder.Environment.IsProduction())
{
    builder.Configuration.AddAzureIdentity(builder.Configuration);
}

var app = builder.Build();

//Middlewares
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapOpenApi();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Scalar

app.MapScalarApiReference(options => {
    options.WithTheme(ScalarTheme.BluePlanet);
});

app.UseAuthentication(); //Aplicar as politicas de autenticação
app.UseAuthorization(); //Verificar as permissões de acesso

app.MapControllers();
app.Run();