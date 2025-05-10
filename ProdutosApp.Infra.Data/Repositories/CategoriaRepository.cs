using ProdutosApp.Domain.Entities;
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
    /// Repositório de dados para categoria
    /// </summary>
    public class CategoriaRepository : BaseRepository<Categoria, Guid?>, ICategoriaRepository
    {
        public CategoriaRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
