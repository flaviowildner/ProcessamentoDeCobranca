using System.Collections.Generic;
using System.Diagnostics;
using CalculadorDeConsumo.Services.CalculadorDeConsumo;
using ClienteAPI.Models.DTO;
using ClienteAPI.Persistence.Contexts;
using Xunit;
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

        [Fact]
        public void testPerformance()
        {
            int nClientes = 1_000_000;
            Dictionary<string, ClienteDTO> clientes = new Dictionary<string, ClienteDTO>();
            for (int i = 0; i < nClientes; i++)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Cpf = DbInitializer.GerarCpf();
                cliente.Nome = "Nome_" + i;
                cliente.Estado = "Estado_" + i;

                if (!clientes.ContainsKey(cliente.Cpf))
                {
                    clientes.Add(cliente.Cpf, cliente);
                }
                else
                {
                    i--;
                }
            }

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            foreach (var cliente in clientes.Values)
            {
                _calculadorDeConsumo.Calcula(cliente);
            }
            stopwatch.Stop();

            _testOutputHelper.WriteLine("Elapsed={0}", stopwatch.Elapsed);
        }
    }
}