using Azure.Identity;
using ProdutosApp.Application.Extensions;
using ProdutosApp.Domain.Extensions;
using ProdutosApp.Infra.Data.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Controller + Scalar
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Key Vault
string? keyVaultError = null;

try
{
    var keyVaultUrl = $"https://coti.vault.azure.net/";
    builder.Configuration.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());
}
catch (Exception ex)
{
    // Armazena o erro em uma variável que será usada no pipeline da aplicação
    keyVaultError = $"Erro ao acessar o Key Vault: {ex.Message}";
    Console.WriteLine(">>> ERRO KEY VAULT: " + ex);
}

// Injeção de dependência (dependendo do erro, pode falhar)
builder.Services.AddApplicationServices();
builder.Services.AddDomainServices();
builder.Services.AddEntityFramework(builder.Configuration);

var app = builder.Build();

if (!string.IsNullOrEmpty(keyVaultError))
{
    app.Run(async context =>
    {
        context.Response.StatusCode = 500;
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync($@"{{ ""erro"": ""{keyVaultError}"" }}");
    });
}
else
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthorization();
    app.MapControllers();
    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.BluePlanet);
    });
}

app.Run();
