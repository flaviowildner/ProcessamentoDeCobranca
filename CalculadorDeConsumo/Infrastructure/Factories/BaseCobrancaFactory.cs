using CalculadorDeConsumo.Services.CalculadorDeConsumo;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Infrastructure.Factories
{
    public abstract class BaseCobrancaFactory : ICobrancaFactory
    {
        protected readonly ICalculadorDeConsumo CalculadorDeConsumo;

        public BaseCobrancaFactory(ICalculadorDeConsumo calculadorDeConsumo)
        {
            CalculadorDeConsumo = calculadorDeConsumo;
        }

        public abstract CobrancaDTO Create();

        public abstract CobrancaDTO Create(ClienteDTO cliente);
    }
}