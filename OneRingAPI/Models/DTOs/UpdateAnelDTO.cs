using OneRingAPI.Enums;
using System.ComponentModel.DataAnnotations;

namespace OneRingAPI.Models.DTOs
{
    /// <summary>
    /// DTO para atualização parcial de um anel.
    /// </summary>
    public class UpdateAnelDTO
    {
        /// <summary>
        /// Nome do anel.
        /// </summary>
        [MaxLength(100)]
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição do poder do anel.
        /// </summary>
        [MaxLength(255)]
        public string? Poder { get; set; }

        /// <summary>
        /// Nome do portador do anel.
        /// </summary>
        [MaxLength(100)]
        public string? Portador { get; set; }

        /// <summary>
        /// Nome do forjador do anel.
        /// </summary>
        [MaxLength(100)]
        public string? ForjadoPor { get; set; }

        /// <summary>
        /// Tipo do portador do anel.
        /// </summary>
        public TipoPortador? Tipo { get; set; }

        /// <summary>
        /// Imagem que representa o anel.
        /// </summary>
        public string? Imagem { get; set; }
    }
}