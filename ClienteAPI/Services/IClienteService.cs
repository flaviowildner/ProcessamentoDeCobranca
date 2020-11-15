using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Models.Entity;

namespace ClienteAPI.Services
{
    public interface IClienteService
    {
        Task AddAsync(Cliente cliente);
        Task<Cliente> FindByCpf(long cpf);
        Task<IEnumerable<Cliente>> ListAsync();
    }
}