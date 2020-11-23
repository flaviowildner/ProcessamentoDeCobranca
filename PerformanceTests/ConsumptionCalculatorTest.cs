using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using RegistradorDeCobranca.Infrastructure.Factories;
using RegistradorDeCobranca.Services.ConsumptionCalculator;
using ClienteAPI.Models.DTO;
using Xunit;
using Xunit.Abstractions;

namespace PerformanceTests
{
    public class ConsumptionCalculatorTest
    {
        private readonly ICobrancaFactory _cobrancaFactory;

        private readonly Stopwatch stopwatch = new Stopwatch();
        private readonly ITestOutputHelper _testOutputHelper;

        public ConsumptionCalculatorTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _cobrancaFactory = new CobrancaFactory(new CpfBasedConsumptionCalculator());
        }

        [Fact]
        public void CreateCobrancasForTheNClientes()
        {
            int nClientes = 500_000;
            IEnumerable<ClienteDTO> clientes = randomClientes(nClientes);

            stopwatch.Start();
            clientes.Select(cliente => _cobrancaFactory.Create()).ToList();
            stopwatch.Stop();


            _testOutputHelper.WriteLine(
                "Time taken to create {0} cobrancas: " + stopwatch.Elapsed.Milliseconds + " milliseconds", nClientes);
        }

        private static IEnumerable<ClienteDTO> randomClientes(int nClientes)
        {
            List<ClienteDTO> clientes = new List<ClienteDTO>();
            for (int i = 0; i < nClientes; i++)
            {
                ClienteDTO cliente = new ClienteDTO();
                cliente.Cpf = GerarCpf();
                cliente.Nome = "Nome_" + i;
                cliente.Estado = "Estado_" + i;

                clientes.Add(cliente);
            }

            return clientes;
        }

        private static String GerarCpf()
        {
            int sum = 0, mod = 0;
            int[] multiplier1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplier2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            Random rnd = new Random();
            string seed = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier1[i];

            mod = sum % 11;
            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            seed = seed + mod;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(seed[i].ToString()) * multiplier2[i];

            mod = sum % 11;

            if (mod < 2)
                mod = 0;
            else
                mod = 11 - mod;

            seed = seed + mod;
            return seed;
        }
    }
}