using RegistradorDeCobranca.Services.ConsumptionCalculator;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace RegistradorDeCobranca.Infrastructure.Factories
{
    public abstract class BaseCobrancaFactory : ICobrancaFactory
    {
        protected readonly IConsumptionCalculator ConsumptionCalculator;

        public BaseCobrancaFactory(IConsumptionCalculator consumptionCalculator)
        {
            ConsumptionCalculator = consumptionCalculator;
        }

        public abstract CobrancaDTO Create();

        public abstract CobrancaDTO Create(ClienteDTO cliente);
    }
}