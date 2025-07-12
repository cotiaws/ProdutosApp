using Microsoft.EntityFrameworkCore;
using ProdutosApp.Contexts;
using ProdutosApp.Dtos;
using ProdutosApp.Entities;

namespace ProdutosApp.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para categoria
    /// </summary>
    public class CategoriaRepository
    {
        //Método para consultar todas as categorias do banco de dados
        public List<Categoria> Consultar()
        {
            //abrindo conexão com o banco de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Categoria>() //consultando dados da tabela de categoria
                        .OrderBy(p => p.Nome) //ordem alfabética de nome
                        .ToList(); //retornando uma listagem com todas as categorias
            }
        }

        //Método para retorne o somatório da quantidade de produtos
        //por cada categoria, usando uma função GROUP BY do banco de dados
        public List<CategoriaQtdProdutosResponseDto> GroupByQtdProdutos()
        {
            //abrindo conexão com o banco de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>() //consultando a entidade Produto
                        .Include(p => p.Categoria) //junção (JOIN) com a entidade Categoria
                        .GroupBy(c => c.Categoria.Nome) //agrupando pelo nome da categoria
                        .Select(g => new CategoriaQtdProdutosResponseDto 
                        { 
                            Categoria = g.Key, //chave do agrupament (nome da categoria)
                            QtdProdutos = g.Sum(p => p.Quantidade) //calculo do agrupamento
                        })
                        .OrderByDescending(dto => dto.QtdProdutos) //ordem decrescente
                        .ToList(); //retornando a lista de resultados
            }
        }

        //Método para retorne a média de preços de produtos
        //por cada categoria, usando uma função GROUP BY do banco de dados
        public List<CategoriaMediaPrecoResponseDto> GroupByMediaPreco()
        {
            //abrindo conexão com o banco de dados através do EntityFramework
            using (var dataContext = new DataContext())
            {
                return dataContext
                        .Set<Produto>() //consultando a entidade Produto
                        .Include(p => p.Categoria) //junção (JOIN) com a entidade Categoria
                        .GroupBy(c => c.Categoria.Nome) //agrupando pelo nome da categoria
                        .Select(g => new CategoriaMediaPrecoResponseDto
                        {
                            Categoria = g.Key, //chave do agrupament (nome da categoria)
                            MediaPreco = g.Average(p => p.Preco) //calculo do agrupamento
                        })
                        .OrderByDescending(dto => dto.MediaPreco) //ordem decrescente
                        .ToList(); //retornando a lista de resultados
            }
        }
    }
}
