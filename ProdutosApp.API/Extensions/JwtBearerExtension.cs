using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ProdutosApp.API.Extensions
{
    public static class JwtBearerExtension
    {
        public static IServiceCollection AddJwtBearerConfig(this IServiceCollection services, IConfiguration configuration)
        {
            //lendo as configurações do appsettings.json
            var jwtSettings = new JwtSettings();
            new ConfigureFromConfigurationOptions<JwtSettings>
                (configuration.GetSection("JwtSettings"))
                .Configure(jwtSettings);

            //injeção de dependência das configurações
            services.AddSingleton(jwtSettings);

            //definindo a politica / esquema de autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                //configurações para validar o token
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //validando o emissor do token
                    ValidateAudience = true, //validando o destinatário do token
                    ValidateLifetime = true, //validando a expiração do token
                    ValidateIssuerSigningKey = true, //valida a chave de assinatura do token
                    ValidIssuer = jwtSettings.Issuer, //comparando o emissor
                    ValidAudience = jwtSettings.Audience, //comparando o destinatário
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
                    //comparando a chave secreta que assina o token
                };
            });

            return services;
        }
    }

    public class JwtSettings
    {
        public string? SecretKey { get; set; }
        public string? Issuer { get; set; }
        public string? Audience { get; set; }
    }
}
