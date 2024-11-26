using Website_TI.Models.DTO;

namespace Website_TI.Services
{
        public interface IClienteService
        {
            Task<List<Cliente>> GetAllClientesAsync();
            Task<Cliente?> GetClienteByIdAsync(int id);
            Task AddClienteAsync(Cliente cliente);
            Task UpdateClienteAsync(Cliente cliente);
            Task DeleteClienteAsync(int id);
        }
    }