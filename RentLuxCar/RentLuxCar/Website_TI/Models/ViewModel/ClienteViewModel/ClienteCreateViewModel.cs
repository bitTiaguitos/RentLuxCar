using System.ComponentModel.DataAnnotations;


public class ClienteCreateViewModel
{
    [Required]
    [Display(Name = "Nome Completo")]
    public string Nome { get; set; }

    [Required]
    [Display(Name = "Gênero")]
    public string Genero { get; set; }

    [Required]
    [Display(Name = "Telemóvel")]
    [Phone]
    public string Telemovel { get; set; }

    [Required]
    [Display(Name = "Senha")]
    [DataType(DataType.Password)]
    public string Senha { get; set; }

    [Required]
    [Display(Name = "Idade")]
    [Range(18, 120, ErrorMessage = "A idade deve ser entre 18 e 120 anos.")]
    public int Idade { get; set; }
}
