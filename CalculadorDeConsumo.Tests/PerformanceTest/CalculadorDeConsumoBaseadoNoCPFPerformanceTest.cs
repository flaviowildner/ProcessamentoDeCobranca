using CalculadorDeConsumo.Services.CalculadorDeConsumo;
using Xunit.Abstractions;

namespace CalculadorDeConsumo.Tests.PerformanceTest
{
    public class CalculadorDeConsumoBaseadoNoCPFPerformanceTest
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly ICalculadorDeConsumo _calculadorDeConsumo;

        public CalculadorDeConsumoBaseadoNoCPFPerformanceTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _calculadorDeConsumo = new CalculadorDeConsumoBaseadoNoCPF();
        }
    }
}