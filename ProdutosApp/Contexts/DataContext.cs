using Microsoft.EntityFrameworkCore;
using ProdutosApp.Mappings;

namespace ProdutosApp.Contexts
{
    /// <summary>
    /// Classe para configuração de todo o contexto do EntityFramework
    /// incluindo conexão com o banco de dados e mapeamento das entidades
    /// </summary>
    public class DataContext : DbContext
    {
        //Método para configurar a conexão com o banco de dados do SqlServer
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=produtosapp-coti.database.windows.net;Initial Catalog=produtosapp-bd;User ID=usuariocoti;Password=Coti@2025;Encrypt=True");
        }

        //Método para adicionar as classes de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
