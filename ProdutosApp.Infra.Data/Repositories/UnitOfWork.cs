using Microsoft.EntityFrameworkCore.Storage;
using ProdutosApp.Domain.Interfaces.Repositories;
using ProdutosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Repositories
{
    /// <summary>
    /// Implementação da unidade de trabalho dos repositórios
    /// </summary>
    public class UnitOfWork (DataContext _dataContext) : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;

        public async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            _transaction = _dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public ICategoriaRepository CategoriaRepository => new CategoriaRepository(_dataContext);

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(_dataContext);

        public void Dispose()
        {
            _transaction?.Dispose();
            _dataContext.Dispose();
        }
    }
}
