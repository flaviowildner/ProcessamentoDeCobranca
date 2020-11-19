using System;
using System.Collections.Generic;
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

            foreach (ClienteDTO cliente in clientes)
            {
                decimal valorCobranca = _calculadorDeConsumo.Calcula(cliente);

                CobrancaDTO cobranca = new CobrancaDTO();
                cobranca.Cpf = cliente.Cpf;
                cobranca.Vencimento = DateTime.Now.AddMonths(1);
                cobranca.Valor = valorCobranca;

                await _apiCommunication.CreateCobranca(cobranca);
            }

            return true;
        }
    }
}