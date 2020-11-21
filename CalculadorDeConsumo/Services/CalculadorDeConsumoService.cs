using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadorDeConsumo.Communication;
using CalculadorDeConsumo.Infrastructure.Factories;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Services
{
    public class CalculadorDeConsumoService : ICalculadorDeConsumoService
    {
        private readonly ICobrancaFactory _cobrancaFactory;
        private readonly IAPICommunication _apiCommunication;

        public CalculadorDeConsumoService(ICobrancaFactory cobrancaFactory, IAPICommunication apiCommunication)
        {
            _apiCommunication = apiCommunication;
            _cobrancaFactory = cobrancaFactory;
        }

        public async Task<bool> Calcula()
        {
            IEnumerable<ClienteDTO> clientes = await _apiCommunication.GetClientes();

            IEnumerable<CobrancaDTO> cobrancaDtos =
                clientes.Select(cliente => _cobrancaFactory.Create(cliente)).ToList();

            return await _apiCommunication.CreateCobrancaBatch(cobrancaDtos);
        }
    }
}