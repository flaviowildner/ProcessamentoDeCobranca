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
        private static HttpClient _httpClient = new HttpClient();

        public async Task<bool> CreateCobrancaBatch(IEnumerable<CobrancaDTO> cobrancas)
        {
            var cobrancaSerialized = new StringContent(
                JsonSerializer.Serialize(cobrancas),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response =
                await _httpClient.PostAsync("https://localhost:44388/api/cobrancas", cobrancaSerialized);

            return response.StatusCode == HttpStatusCode.OK;
        }
    }
}