namespace Website_TI.Models.DTO
{
    public class Pagamentos
    {
        public int Id { get; set; }
        public int IdAluguer { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataPagamento { get; set; }
        public string EstadoPagamento { get; set; }
        public string FormaPagamento { get; set; }
    }
}
