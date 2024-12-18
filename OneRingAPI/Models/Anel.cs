using System.ComponentModel.DataAnnotations;

namespace OneRingAPI.Models
{
    public class Anel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Poder { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Portador { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string ForjadoPor { get; set; } = string.Empty;

        [Required]
        [Url]
        public string Imagem { get; set; } = string.Empty;
    }
}
