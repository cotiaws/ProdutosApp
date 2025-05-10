using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Dtos.Responses
{
    /// <summary>
    /// Modelo de dados da resposta da aplicação
    /// para uma operação de categoria
    /// </summary>
    public class CategoriaResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
    }
}
