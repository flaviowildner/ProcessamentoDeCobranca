using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClienteAPI.Persistence.Repositories;
using ClienteAPI.Models.Entity;
using ClienteAPI.Models.Services;

namespace ClienteAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        private async Task<bool> ExistsAsync(long cpf)
        {
            ClienteResponse clienteResponse = await FindByCpf(cpf);
            return clienteResponse.Success && clienteResponse.Resource != null;
        }

        public async Task<ClienteResponse> AddAsync(Cliente cliente)
        {
            if (await ExistsAsync(cliente.Cpf))
            {
                return new ClienteResponse("Duplicated CPF");
            }

            try
            {
                await _clienteRepository.AddAsync(cliente);

                return new ClienteResponse(cliente);
            }
            catch (Exception ex)
            {
                return new ClienteResponse($"An error ocurred while saving cliente: {ex.Message}");
            }
        }

        public async Task<ClienteResponse> FindByCpf(long cpf)
        {
            try
            {
                Cliente cliente = await _clienteRepository.FindByCpf(cpf);
                return new ClienteResponse(cliente);
            }
            catch (Exception ex)
            {
                return new ClienteResponse($"An error ocurred while finding cliente: {ex.Message}");
            }
        }

        public async Task<ClienteListResponse> ListAsync()
        {
            try
            {
                IEnumerable<Cliente> clientes = await _clienteRepository.ListAsync();
                return new ClienteListResponse(clientes);
            }
            catch (Exception ex)
            {
                return new ClienteListResponse($"An error ocurred while getting clientes: {ex.Message}");
            }
        }
    }
}