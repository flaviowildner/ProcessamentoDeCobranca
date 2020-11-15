using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Persistence.Repositories;
using ClienteAPI.Models.Entity;

namespace ClienteAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _clienteRepository.AddAsync(cliente);
        }

        public async Task<Cliente> FindByCpf(long cpf)
        {
            return await _clienteRepository.FindByCpf(cpf);
        }

        public async Task<IEnumerable<Cliente>> ListAsync()
        {
            return await _clienteRepository.ListAsync();
        }
    }
}