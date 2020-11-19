using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
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

            return (IEnumerable<ClienteDTO>) await response.Content.ReadFromJsonAsync(typeof(IEnumerable<ClienteDTO>));
        }

        public async Task<CobrancaDTO> CreateCobranca(CobrancaDTO cobranca)
        {
            HttpResponseMessage response =
                await _httpClient.PostAsJsonAsync("https://localhost:44388/api/cobrancas", cobranca);

            return (CobrancaDTO) await response.Content.ReadFromJsonAsync(typeof(CobrancaDTO));
        }
    }
}