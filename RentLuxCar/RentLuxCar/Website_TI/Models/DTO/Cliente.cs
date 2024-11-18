namespace Website_TI.Models.DTO
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public char Genero { get; set; }
        public string Telemovel { get; set; }
        public int Idade { get; set; }
        public DateTime DataDeCriacao { get; set; }
    }
}
