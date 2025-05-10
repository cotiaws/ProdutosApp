using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface para operações de serviço de domínio de categoria
    /// </summary>
    public interface ICategoriaDomainService
    {
        Task<List<Categoria>> ObterTodos();
    }
}
