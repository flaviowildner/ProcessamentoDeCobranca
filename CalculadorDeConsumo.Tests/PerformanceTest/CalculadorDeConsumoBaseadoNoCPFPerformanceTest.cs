using CalculadorDeConsumo.Services.ConsumptionCalculator;
using Xunit.Abstractions;

namespace CalculadorDeConsumo.Tests.PerformanceTest
{
    public class CalculadorDeConsumoBaseadoNoCPFPerformanceTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly IConsumptionCalculator _consumptionCalculator;

        public CalculadorDeConsumoBaseadoNoCPFPerformanceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _consumptionCalculator = new CpfBasedConsumptionCalculator();
        }
    }
}