using System.ComponentModel.DataAnnotations;

namespace Website_TI.Models.ViewModel
{
    public class ClienteCreateViewModel
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        [Phone]
        public string Telemovel { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Senha { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Idade must be between 1 and 120.")]
        public int Idade { get; set; }
    }
}
