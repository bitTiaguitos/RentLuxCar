namespace Website_TI.Models.DTO
{
    public class Aluguer
    {
        public int Id { get; set; }
        public string CarroAlugado { get; set; }
        public DateTime DataDeAluguer { get; set; }
        public DateTime InicioAluguer { get; set; }
        public DateTime FimAluguer { get; set; }
        public DateTime EntregaViaturaAluguer { get; set; }
        public int IdCliente { get; set; }
    }
}
