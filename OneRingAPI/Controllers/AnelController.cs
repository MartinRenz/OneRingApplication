using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OneRingAPI.Models;

namespace OneRingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnelController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var anel = new Anel
            {
                Id = 1,
                Nome = "Anel do Poder Supremo",
                Poder = "Controla todos os outros anéis",
                Portador = "Sauron",
                ForjadoPor = "Sauron",
                Imagem = "https://example.com/anel.png"
            };

            return Ok(anel);
        }
    }
}
