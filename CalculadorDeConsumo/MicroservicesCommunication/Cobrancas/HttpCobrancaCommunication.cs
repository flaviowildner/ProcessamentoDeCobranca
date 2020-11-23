using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.MicroservicesCommunication.Cobrancas
{
    public class HttpCobrancaCommunication : ICobrancaCommunication
    {
        private readonly string _baseAddress;
        private static readonly HttpClient HttpClient = new HttpClient();

        public HttpCobrancaCommunication(String baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public async Task<bool> CreateCobrancaBatch(IEnumerable<CobrancaDTO> cobrancas)
        {
            var cobrancaSerialized = new StringContent(
                JsonSerializer.Serialize(cobrancas),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response =
                await HttpClient.PostAsync($"{_baseAddress}/api/cobrancas", cobrancaSerialized);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}