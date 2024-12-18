using Microsoft.AspNetCore.Mvc;
using OneRingAPI.Models;
using OneRingAPI.Services;

namespace OneRingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnelController : ControllerBase
    {
        private readonly AnelService _anelService;
        private readonly ILogger<AnelController> _logger;

        public AnelController(
            AnelService anelService,
            ILogger<AnelController> logger
        )
        {
            _anelService = anelService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var aneis = await _anelService.GetAllAsync();

                if (!aneis.Any())
                {
                    var response = new DataResponse<List<Anel>>("Nenhum anel encontrado.", null);
                    return NotFound(response);
                }

                var successResponse = new DataResponse<List<Anel>>("Anéis encontrados com sucesso.", aneis);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar requisição de anéis.");

                var errorResponse = new DataResponse<object>("Ocorreu um erro inesperado.", null);
                return StatusCode(500, errorResponse);
            }
        }
    }
}