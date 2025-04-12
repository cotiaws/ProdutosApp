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
            optionsBuilder.UseSqlServer("Data Source=localhost,1434;Initial Catalog=master;User ID=sa;Password=Coti@2025;Encrypt=False");
        }

        //Método para adicionar as classes de mapeamento do projeto
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
