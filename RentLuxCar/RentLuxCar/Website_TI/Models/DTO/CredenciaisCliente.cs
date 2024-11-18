namespace Website_TI.Models.DTO
{
    public class CredenciaisCliente
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string NomeUtilizador { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
    }
}
