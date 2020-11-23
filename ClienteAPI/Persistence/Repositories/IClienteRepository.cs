using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Models.Entity;

namespace ClienteAPI.Persistence.Repositories
{
    public interface IClienteRepository
    {
        Task AddAsync(Cliente cliente);
        Task<Cliente> FindByCpf(long cpf);
        Task<IEnumerable<Cliente>> ListAsync(int limit);
    }
}