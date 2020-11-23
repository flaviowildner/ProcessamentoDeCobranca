using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteAPI.Persistence.Contexts;
using ClienteAPI.Models.Entity;
using Microsoft.EntityFrameworkCore;

namespace ClienteAPI.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private ApiDbContext _context;

        public ClienteRepository(ApiDbContext context)
        {
            _context = context;
        }


        public async Task AddAsync(Cliente cliente)
        {
            await _context.Clients.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> FindByCpf(long cpf)
        {
            return await _context.Clients.FindAsync(cpf);
        }

        public async Task<IEnumerable<Cliente>> ListAsync(int limit)
        {
            IQueryable<Cliente> queryable = _context.Clients.AsNoTracking();

            if (limit >= 0)
                queryable = queryable.Take(limit);

            return await queryable.ToListAsync();
        }
    }
}