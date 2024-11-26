using static Website_TI.Services.ClienteService;
using Website_TI.Data;
using Website_TI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace Website_TI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly Website_TIContext _context;

        public ClienteService(Website_TIContext context)
        {
            _context = context;
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente?> GetClienteByIdAsync(int id)
        {
            return await _context.Cliente.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClienteAsync(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClienteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}