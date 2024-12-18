using Microsoft.AspNetCore.Mvc;
using OneRingAPI.Models;
using OneRingAPI.Models.DTOs;
using OneRingAPI.Services;

namespace OneRingAPI.Controllers
{
    /// <summary>
    /// Responsável pelas operações relacionadas aos anéis.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AnelController : ControllerBase
    {
        private readonly AnelService _anelService;
        private readonly ILogger<AnelController> _logger;

        /// <summary>
        /// Construtor para o controlador de anéis.
        /// </summary>
        /// <param name="anelService">Serviço responsável pelas operações de anéis.</param>
        /// <param name="logger">Logger para registrar erros.</param>
        public AnelController(
            AnelService anelService,
            ILogger<AnelController> logger
        )
        {
            _anelService = anelService;
            _logger = logger;
        }

        /// <summary>
        /// Retorna todos os anéis registrados.
        /// </summary>
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

        /// <summary>
        /// Retorna um anel através do ID.
        /// </summary>
        /// <param name="id">O ID do anel que será retornado.</param>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var anel = await _anelService.GetByIdAsync(id);

                if (anel == null)
                {
                    var response = new DataResponse<object>("Anel não encontrado.", null);
                    return NotFound(response);
                }

                var successResponse = new DataResponse<Anel>("Anel encontrado com sucesso.", anel);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao processar requisição de anel por ID.");

                var errorResponse = new DataResponse<object>("Ocorreu um erro inesperado.", null);
                return StatusCode(500, errorResponse);
            }
        }

        /// <summary>
        /// Adiciona um novo anel.
        /// </summary>
        /// <param name="anel">Anel a ser adicionado.</param>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Anel anel)
        {
            try
            {
                var createdAnel = await _anelService.CreateAsync(anel);

                var successResponse = new DataResponse<Anel>("Anel criado com sucesso.", createdAnel);
                return CreatedAtAction(nameof(GetById), new { id = createdAnel.Id }, successResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao criar o anel.");

                var errorResponse = new DataResponse<object>("Ocorreu um erro inesperado ao criar o anel.", null);
                return StatusCode(500, errorResponse);
            }
        }

        /// <summary>
        /// Atualiza as informações de um anel.
        /// </summary>
        /// <param name="id">O ID do anel a ser atualizado.</param>
        /// <param name="anel">Dados do anel a serem atualizados.</param>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAnelDTO anel)
        {
            try
            {
                var updatedAnel = await _anelService.UpdateAsync(id, anel);

                if (updatedAnel == null)
                {
                    return NotFound(new DataResponse<object>("Anel não encontrado.", null));
                }

                var successResponse = new DataResponse<Anel>("Anel atualizado com sucesso.", updatedAnel);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o anel.");

                var errorResponse = new DataResponse<object>("Ocorreu um erro inesperado ao atualizar o anel.", null);
                return StatusCode(500, errorResponse);
            }
        }

        /// <summary>
        /// Deleta um anel pelo ID.
        /// </summary>
        /// <param name="id">O ID do anel a ser deletado.</param>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _anelService.DeleteAsync(id);

                if (!result)
                {
                    var response = new DataResponse<object>("Anel não encontrado.", null);
                    return NotFound(response);
                }

                var successResponse = new DataResponse<object>("Anel deletado com sucesso.", null);
                return Ok(successResponse);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar o anel.");

                var errorResponse = new DataResponse<object>("Ocorreu um erro inesperado ao deletar o anel.", null);
                return StatusCode(500, errorResponse);
            }
        }
    }
}