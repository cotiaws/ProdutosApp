using ProdutosApp.Application.Dtos.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Application.Interfaces
{
    /// <summary>
    /// Interface para serviços de aplicação de categoria
    /// </summary>
    public interface ICategoriaAppService
    {
        Task<List<CategoriaResponse>> ObterTodos();
    }
}
