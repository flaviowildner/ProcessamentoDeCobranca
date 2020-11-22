using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using CalculadorDeConsumo.Infrastructure.Factories;
using CalculadorDeConsumo.Services.ConsumptionCalculator;
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
            int nClientes = 1_000_000;
            IEnumerable<ClienteDTO> clientes = randomClientes(nClientes);

            stopwatch.Start();
            clientes.Select(cliente => _cobrancaFactory.Create()).ToList();
            stopwatch.Stop();


            _testOutputHelper.WriteLine(
                "Time taken to create {0} cobrancas: " + stopwatch.Elapsed.Milliseconds + " milliseconds", nClientes);
        }

        public static IEnumerable<ClienteDTO> randomClientes(int nClientes)
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

        public static String GerarCpf()
        {
            int soma = 0, resto = 0;
            int[] multiplicador1 = new int[9] {10, 9, 8, 7, 6, 5, 4, 3, 2};
            int[] multiplicador2 = new int[10] {11, 10, 9, 8, 7, 6, 5, 4, 3, 2};

            Random rnd = new Random();
            string semente = rnd.Next(100000000, 999999999).ToString();

            for (int i = 0; i < 9; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(semente[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            semente = semente + resto;
            return semente;
        }
    }
}