using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ClienteAPI.Models.DTO;
using CobrancaAPI.Models.DTO;

namespace CalculadorDeConsumo.Communication
{
    public class HttpAPICommunication : IAPICommunication
    {
        private static HttpClient _httpClient = new HttpClient();

        public async Task<IEnumerable<ClienteDTO>> GetClientes()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:44316/api/cliente");

            string clientesString = await response.Content.ReadAsStringAsync();
            
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;
            
            return JsonSerializer.Deserialize<IEnumerable<ClienteDTO>>(clientesString, jsonSerializerOptions);
        }

        public async Task<CobrancaDTO> CreateCobranca(CobrancaDTO cobranca)
        {
            var cobrancaSerialized = new StringContent(
                JsonSerializer.Serialize(cobranca),
                Encoding.UTF8,
                "application/json");

            HttpResponseMessage response =
                await _httpClient.PostAsync("https://localhost:44388/api/cobrancas", cobrancaSerialized);

            return JsonSerializer.Deserialize<CobrancaDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}