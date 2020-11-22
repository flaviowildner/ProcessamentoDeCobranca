using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadorDeConsumo.Infrastructure.Factories;
using CalculadorDeConsumo.MicroservicesCommunication.Clientes;
using CalculadorDeConsumo.MicroservicesCommunication.Cobrancas;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Services
{
    public class CobrancaRegistrationService : ICobrancaRegistrationService
    {
        private readonly ICobrancaFactory _cobrancaFactory;
        private readonly IClienteCommunication _clienteCommunication;
        private readonly ICobrancaCommunication _cobrancaCommunication;

        public CobrancaRegistrationService(ICobrancaFactory cobrancaFactory, IClienteCommunication clienteCommunication,
            ICobrancaCommunication cobrancaCommunication)
        {
            _cobrancaFactory = cobrancaFactory;
            _clienteCommunication = clienteCommunication;
            _cobrancaCommunication = cobrancaCommunication;
        }

        public async Task<bool> Calcula()
        {
            IEnumerable<ClienteDTO> clientes = await _clienteCommunication.GetAllClientes();

            IEnumerable<CobrancaDTO> cobrancaDtos =
                clientes.Select(cliente => _cobrancaFactory.Create(cliente)).ToList();

            return await _cobrancaCommunication.CreateCobrancaBatch(cobrancaDtos);
        }
    }
}