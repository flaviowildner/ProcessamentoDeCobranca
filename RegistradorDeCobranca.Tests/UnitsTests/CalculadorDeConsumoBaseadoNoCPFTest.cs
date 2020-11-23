using ClienteAPI.Models.DTO;
using RegistradorDeCobranca.Services.ConsumptionCalculator;
using Xunit;
using Xunit.Abstractions;

namespace RegistradorDeCobranca.Tests.UnitsTests
{
    public class CalculadorDeConsumoBaseadoNoCPFTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IConsumptionCalculator _consumptionCalculator;
        public CalculadorDeConsumoBaseadoNoCPFTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _consumptionCalculator = new CpfBasedConsumptionCalculator();
        }

        [Fact]
        public void testWithValidCPF()
        {
            ClienteDTO cliente = new ClienteDTO();
            cliente.Cpf = "255.305.154-95";
            cliente.Nome = "Fulano";
            cliente.Estado = "RJ";

            decimal valor = _consumptionCalculator.Calcula(cliente);

            Assert.Equal(2595, valor);
        }
    }
}