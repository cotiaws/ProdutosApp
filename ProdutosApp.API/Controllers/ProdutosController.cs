using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProdutosApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            //Retornar OK (Sucesso)
            return Ok("Consulta realizada com sucesso!");
        }
    }
}
