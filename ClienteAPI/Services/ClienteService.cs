using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClienteAPI.Persistence.Repositories;
using ClienteAPI.Models.Entity;
using ClienteAPI.Models.Services;
using ClienteAPI.Util.Validators;
using FluentValidation;
using FluentValidation.Results;

namespace ClienteAPI.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IValidator<Cliente> _clienteValidator;
        private readonly ICPFValidator _cpfValidator;

        public ClienteService(IClienteRepository clienteRepository, IValidator<Cliente> clienteValidator,
            ICPFValidator cpfValidator)
        {
            _clienteRepository = clienteRepository;
            _clienteValidator = clienteValidator;
            _cpfValidator = cpfValidator;
        }

        private async Task<bool> ExistsAsync(long cpf)
        {
            ClienteResponse clienteResponse = await FindByCpf(cpf);
            return clienteResponse.Success && clienteResponse.Resource != null;
        }

        public async Task<ClienteResponse> AddAsync(Cliente cliente)
        {
            ValidationResult validationResult = await _clienteValidator.ValidateAsync(cliente);
            if (!validationResult.IsValid)
            {
                return new ClienteResponse(validationResult.Errors
                    .Select(error => error.ErrorMessage)
                    .ToArray()
                );
            }

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
            if (!_cpfValidator.IsValid(cpf))
            {
                return new ClienteResponse("Invalid CPF");
            }

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

        public async Task<ClienteListResponse> ListAsync(int limit)
        {
            try
            {
                IEnumerable<Cliente> clientes = await _clienteRepository.ListAsync(limit);
                return new ClienteListResponse(clientes);
            }
            catch (Exception ex)
            {
                return new ClienteListResponse($"An error ocurred while getting clientes: {ex.Message}");
            }
        }
    }
}