using System;
using CalculadorDeConsumo.Services.CalculadorDeConsumo;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Infrastructure.Factories
{
    public class CobrancaFactory : BaseCobrancaFactory
    {
        public CobrancaFactory(ICalculadorDeConsumo calculadorDeConsumo) : base(calculadorDeConsumo)
        {
        }

        public override CobrancaDTO Create()
        {
            return new CobrancaDTO();
        }

        public override CobrancaDTO Create(ClienteDTO cliente)
        {
            CobrancaDTO cobrancaDto = Create();
            cobrancaDto.Cpf = cliente.Cpf;
            cobrancaDto.Vencimento = DateTime.Now.AddMonths(1);
            cobrancaDto.Valor = CalculadorDeConsumo.Calcula(cliente);

            return cobrancaDto;
        }
    }
}