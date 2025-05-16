using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProdutosApp.Application.Dtos.Responses;
using ProdutosApp.Application.Interfaces;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController (ICategoriaAppService _categoriaAppService, IConfiguration _configuration) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaResponse>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoriaAppService.ObterTodos());
        }

        [HttpGet("connectionstring")]
        public IActionResult GetConnectionString()
        {
            // Lê a connection string com base no nome definido no appsettings
            var conn = _configuration.GetConnectionString("ProdutosAppBD");

            if (string.IsNullOrWhiteSpace(conn))
                return NotFound("Connection string não encontrada.");

            return Ok(conn);
        }
    }
}
