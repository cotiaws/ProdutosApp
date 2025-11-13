using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Adicionando os serviços do Swagger (documentação da API)
builder.Services.AddEndpointsApiExplorer(); //Swagger
builder.Services.AddSwaggerGen(); //Swagger

//Ler as configurações de origens mapeadas no appsettings.json
var allowedOrigins = builder.Configuration.GetSection("AllowedOrigins").Get<string[]>();

//Configuração do CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        policy => policy
            .WithOrigins(allowedOrigins!) //valores do appsettings.json
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Executando os serviços do Swagger (documentação da API)
app.UseSwagger(); //Swagger
app.UseSwaggerUI(); //Swagger

//Executando os serviços do Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

//Configuração do CORS
app.UseCors("AllowOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
