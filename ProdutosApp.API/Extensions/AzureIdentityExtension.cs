﻿using Azure.Identity;

namespace ProdutosApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para acessarmos as informação de identificação
    /// e de cofres de chaves na azure
    /// </summary>
    public static class AzureIdentityExtension
    {
        public static IConfigurationBuilder AddAzureIdentity(this IConfigurationBuilder builder, IConfiguration configuration)
        {
            var keyVaultUrl = configuration["AzureKeyVault"];

            builder.AddAzureKeyVault(new Uri(keyVaultUrl), new DefaultAzureCredential());

            return builder;
        }
    }
}
