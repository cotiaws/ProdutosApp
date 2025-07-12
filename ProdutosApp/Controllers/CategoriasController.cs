using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Repositories;

namespace ProdutosApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        /// <summary>
        /// Método para consultar as categorias na API.
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            //criando um objeto da classe de repositório de categorias
            var categoriaRepository = new CategoriaRepository();

            //consultando todas as categorias (lista de categorias)
            var categorias = categoriaRepository.Consultar();

            //retornando a lista para o cliente da API
            return Ok(categorias);
        }
    }
}
