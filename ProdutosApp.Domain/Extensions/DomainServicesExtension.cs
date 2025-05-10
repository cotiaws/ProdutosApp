using Microsoft.Extensions.DependencyInjection;
using ProdutosApp.Domain.Interfaces.Services;
using ProdutosApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Extensions
{
    /// <summary>
    /// Classe de extensão para configurar as injeções de dependência dos serviços de domínio.
    /// </summary>
    public static class DomainServicesExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<ICategoriaDomainService, CategoriaDomainService>();

            return services;
        }
    }
}
