using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para unidade de trabalho dos repositórios
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        #region Gerenciamento de transações

        Task SaveChangesAsync();

        void BeginTransaction();
        void Commit();
        void Rollback();

        #endregion

        #region Propriedades para acesso aos repositórios

        ICategoriaRepository CategoriaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }

        #endregion
    }
}
