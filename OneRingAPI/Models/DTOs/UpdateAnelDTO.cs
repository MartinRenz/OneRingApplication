using OneRingAPI.Enums;

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
        public string? Nome { get; set; }

        /// <summary>
        /// Descrição do poder do anel.
        /// </summary>
        public string? Poder { get; set; }

        /// <summary>
        /// Nome do portador do anel.
        /// </summary>
        public string? Portador { get; set; }

        /// <summary>
        /// Nome do forjador do anel.
        /// </summary>
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