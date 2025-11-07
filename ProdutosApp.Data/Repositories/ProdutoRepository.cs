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
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProdutosApp;Integrated Security=True;";

        public void Adicionar(Produto produto)
        {
            var sql = @"
                INSERT INTO PRODUTO(ID, NOME, DESCRICAO, PRECO, QUANTIDADE, DATACADASTRO, ATIVO)
                VALUES(@Id, @Nome, @Descricao, @Preco, @Quantidade, @DataCadastro, @Ativo)
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, produto);
            }
        }

        public void Atualizar(Produto produto)
        {
            var sql = @"
                UPDATE PRODUTO 
                SET NOME = @Nome, DESCRICAO = @Descricao, PRECO = @Preco, QUANTIDADE = @Quantidade
                WHERE ID = @Id  
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, produto);
            }
        }

        public void Excluir(Guid id)
        {
            var sql = @"
                UPDATE PRODUTO
                SET ATIVO = 0
                WHERE ID = @Id
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(sql, new { @Id = id });
            }
        }

        public List<Produto> ObterTodos()
        {
            var sql = @"
                SELECT
	                ID, NOME, DESCRICAO, PRECO, QUANTIDADE, DATACADASTRO, ATIVO
                FROM PRODUTO
                WHERE ATIVO = 1
                ORDER BY NOME;
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Produto>(sql).ToList();
            }
        }

        public Produto? ObterPorId(Guid id)
        {
            var sql = @"
                SELECT 
                    ID, NOME, DESCRICAO, PRECO, QUANTIDADE, DATACADASTRO, ATIVO
                FROM PRODUTO
                WHERE ID = @Id AND ATIVO = 1;
            ";

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query(sql, new { @Id = id }).SingleOrDefault();
            }
        }
    }
}
