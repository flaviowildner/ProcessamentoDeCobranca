using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CalculadorDeConsumo.Communication;
using CalculadorDeConsumo.Services.CalculadorDeConsumo;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Services
{
    public class CalculadorDeConsumoService : ICalculadorDeConsumoService
    {
        private readonly IAPICommunication _apiCommunication;
        private readonly ICalculadorDeConsumo _calculadorDeConsumo;

        public CalculadorDeConsumoService(IAPICommunication apiCommunication, ICalculadorDeConsumo calculadorDeConsumo)
        {
            _apiCommunication = apiCommunication;
            _calculadorDeConsumo = calculadorDeConsumo;
        }

        public async Task<bool> Calcula()
        {
            IEnumerable<ClienteDTO> clientes = await _apiCommunication.GetClientes();

            IEnumerable<CobrancaDTO> cobrancaDtos = clientes.Select(cliente => GenerateCobranca(cliente)).ToList();

            return await _apiCommunication.CreateCobrancaBatch(cobrancaDtos);
        }

        private CobrancaDTO GenerateCobranca(ClienteDTO cliente)
        {
            decimal valorCobranca = _calculadorDeConsumo.Calcula(cliente);

            CobrancaDTO cobrancaDto = new CobrancaDTO();
            cobrancaDto.Cpf = cliente.Cpf;
            cobrancaDto.Vencimento = DateTime.Now.AddMonths(1);
            cobrancaDto.Valor = valorCobranca;

            return cobrancaDto;
        }
    }
}