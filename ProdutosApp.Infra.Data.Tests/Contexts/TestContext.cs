using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Tests.Contexts
{
    /// <summary>
    /// Classe para contexto e preparação dos testes
    /// </summary>
    public class TestContext
    {
        /// <summary>
        /// Método para configurar e retornar uma instância da classe DataContext
        /// </summary>
        public static DataContext CreateDataContext()
        {            
            var options = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ProdutosAppTest")
                .Options;

            return new DataContext(options);
        }  
    }
}
