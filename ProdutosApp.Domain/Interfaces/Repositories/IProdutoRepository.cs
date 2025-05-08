using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para repositório de Produto
    /// </summary>
    public interface IProdutoRepository : IBaseRepository<Produto, Guid?>
    {

    }
}
