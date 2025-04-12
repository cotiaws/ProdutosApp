using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Entities;

namespace ProdutosApp.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Categoria
    /// </summary>
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            //nome da tabela no banco de dados
            builder.ToTable("CATEGORIA");

            //chave primária da tabela
            builder.HasKey(c => c.Id);

            //mapeamento dos campos da tabela
            builder.Property(c => c.Id).HasColumnName("ID");
            builder.Property(c => c.Nome).HasColumnName("NOME").HasMaxLength(50).IsRequired();

            //mapeando o campo 'Nome' como único na tabela, ou seja,
            //não deverá permitr valores duplicados
            builder.HasIndex(c => c.Nome).IsUnique();
        }
    }
}
