using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace Website_TI.Models.ViewModel
{
    public class ViaturasCreateViewModel
    {
        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        [Range(1886, 9999, ErrorMessage = "Por favor, insira um ano válido.")]
        public int Ano { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço por hora deve ser positivo.")]
        public decimal PrecoHora { get; set; }

        [Required]
        public string TipoAluguer { get; set; }

        // Path to the image file (optional, but highly recommended for handling images dynamically)
        [Required(ErrorMessage = "Por favor, selecione um arquivo de imagem.")]
        [Display(Name = "Imagem")]
        public string DirImagem { get; set; }

        [Required]
        public string Motor { get; set; }

        [Required]
        public string Potencia { get; set; }

        [Required]
        public string Transmissao { get; set; }

        [Required]
        public string Vmax { get; set; }

        [Required]
        public string aceleracao { get; set; }

        [Required]
        public string Peso { get; set; }

        [Display(Name = "Upload Image")]
        public IFormFile ImageFile { get; set; } // For image upload
    }

}