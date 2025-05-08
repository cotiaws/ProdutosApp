using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Mappings
{
    /// <summary>
    /// Classe para mapeamento da entidade Categoria no banco de dados
    /// </summary>
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id); //chave primária

            builder.Property(c => c.Nome)
                .HasMaxLength(50) //varchar(50)
                .IsRequired(); //not null

            builder.HasIndex(c => c.Nome) //criando um índice
                .IsUnique(); //definindo o campo como único
        }
    }
}
