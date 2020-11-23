using System.Threading.Tasks;
using ClienteAPI.Models.Entity;
using ClienteAPI.Models.Services;

namespace ClienteAPI.Services
{
    public interface IClienteService
    {
        Task<ClienteResponse> AddAsync(Cliente cliente);
        Task<ClienteResponse> FindByCpf(long cpf);
        Task<ClienteListResponse> ListAsync(int limit);
    }
}