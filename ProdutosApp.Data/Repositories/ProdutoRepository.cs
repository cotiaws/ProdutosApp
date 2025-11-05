using Dapper;
using Microsoft.Data.SqlClient;
using ProdutosApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Data.Repositories
{
    /// <summary>
    /// Repositorio para operações relacionadas a produtos.
    /// </summary>
    public class ProdutoRepository
    {
        public List<Produto> ObterTodos()
        {
            var sql = @"
                SELECT
	                ID, NOME, DESCRICAO, PRECO, QUANTIDADE, DATACADASTRO, ATIVO
                FROM PRODUTO
                WHERE ATIVO = 1
                ORDER BY NOME;
            ";

            using (var connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProdutosApp;Integrated Security=True;"))
            {
                return connection.Query<Produto>(sql).ToList();
            }
        }
    }
}
