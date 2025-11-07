using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.API.Dtos;
using ProdutosApp.Data.Entities;
using ProdutosApp.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            //Criando um novo produto
            var produto = new Produto()
            {
                Nome = request.Nome, //Capturando o nome do produto
                Descricao = request.Descricao, //Capturando a descrição do produto
                Preco = request.Preco, //Capturando o preço do produto
                Quantidade = request.Quantidade, //Capturando a quantidade do produto
            };

            //Instanciando a classe ProdutoRepository (objeto)
            var produtoRepository = new ProdutoRepository();
            produtoRepository.Adicionar(produto); //enviando o produto para o banco de dados

            //Retornando sucesso
            return Ok(new {
                Mensagem = "Produto cadastrado com sucesso"
            });
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Instanciando a classe ProdutoRepository (objeto)
            var produtoRepository = new ProdutoRepository();

            //Consultando os produtos no banco de dados e guardar
            //o retorno em uma variavel do tipo lista
            var produtos = produtoRepository.ObterTodos();

            //Copiando os produtos da lista obtida do banco de dados
            //Para uma outra lista do tipo ProdutoResponse (DTO)
            var produtosDto = produtos.Select(p => new ProdutoResponse(
                                    p.Id, //Id do produto
                                    p.Nome, //Nome do produto
                                    p.Descricao, //Descrição do produto
                                    p.Preco, //Preço do produto
                                    p.Quantidade, //Quantidade do produto
                                    p.DataCadastro //Data de cadastro do produto
                                )).ToList();

            //Retornar OK (Sucesso)
            return Ok(produtosDto);
        }
    }
}
