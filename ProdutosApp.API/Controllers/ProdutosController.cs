using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Data.Repositories;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            //Instanciando a classe ProdutoRepository (objeto)
            var produtoRepository = new ProdutoRepository();

            //Consultando os produtos no banco de dados e guardar
            //o retorno em uma variavel do tipo lista
            var produtos = produtoRepository.ObterTodos();

            //Retornar OK (Sucesso)
            return Ok(produtos);
        }
    }
}
