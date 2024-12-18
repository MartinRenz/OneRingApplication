using OneRingAPI.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OneRingAPI.Models
{
    /// <summary>
    /// Representa um anel no universo de Senhor dos Anéis.
    /// </summary>
    public class Anel
    {
        /// <summary>
        /// ID único do anel.
        /// </summary>
        [Key]
        [JsonIgnore]
        public int Id { get; set; }

        /// <summary>
        /// Nome do anel.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        /// <summary>
        /// Descrição do poder do anel.
        /// </summary>
        [Required]
        [MaxLength(255)]
        public string Poder { get; set; } = string.Empty;

        /// <summary>
        /// Nome do portador do anel.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Portador { get; set; } = string.Empty;

        /// <summary>
        /// Nome de do forjador do anel.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string ForjadoPor { get; set; } = string.Empty;

        /// <summary>
        /// Nome do forjador do anel.
        /// </summary>
        [Required]
        public TipoPortador Tipo { get; set; }

        /// <summary>
        /// Imagem que representa o anel.
        /// </summary>
        [Required]
        [Url]
        public string Imagem { get; set; } = string.Empty;
    }
}
