﻿using Microsoft.AspNetCore.Mvc;
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
    }
}