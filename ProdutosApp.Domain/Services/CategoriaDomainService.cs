using ProdutosApp.Domain.Entities;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Services
{
    /// <summary>
    /// Implementação dos serviços de domínio de categoria
    /// </summary>
    public class CategoriaDomainService (IUnitOfWork unitOfWork) : ICategoriaDomainService
    {
        public async Task<List<Categoria>> ObterTodos()
        {
            return await unitOfWork.CategoriaRepository.GetAllAsync();
        }
    }
}
