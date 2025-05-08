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
    /// Classe para mapeamento da entidade Produto no banco de dados
    /// </summary>
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id); //chave primária

            builder.Property(p => p.Nome)
                .HasMaxLength(50) //varchar(50)
                .IsRequired(); //not null

            builder.Property(p => p.Preco)
                .HasColumnType("decimal(18,2)") //decimal(18,2)
                .IsRequired(); //not null

            builder.Property(p => p.Quantidade)
                .IsRequired(); //not null

            builder.Property(p => p.DataHoraCriacao)
                .HasColumnType("datetime") //datetime
                .IsRequired(); //not null

            builder.Property(p => p.Ativo)
                .IsRequired(); //not null

            builder.Property(p => p.CategoriaId)
                .IsRequired(); //not null

            builder.HasOne(p => p.Categoria) //Produto TEM 1 Categoria
                .WithMany(c => c.Produtos) //Categoria TEM muitos Produtos
                .HasForeignKey(p => p.CategoriaId) //chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); //comportamento de exclusão restritivo
        }
    }
}
