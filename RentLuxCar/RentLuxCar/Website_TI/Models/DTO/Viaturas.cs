namespace Website_TI.Models.DTO
{
    public class Viaturas
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Tipo { get; set; }
        public int Ano { get; set; }
        public decimal PrecoHora { get; set; }
        public string TipoAluguer { get; set; }
    }
}
