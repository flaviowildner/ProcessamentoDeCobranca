using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using ClienteAPI.Models.DTO;

namespace CalculadorDeConsumo.MicroservicesCommunication.Clientes
{
    public class HttpClienteCommunication : IClienteCommunication
    {
        private static HttpClient _httpClient = new HttpClient();

        public async Task<IEnumerable<ClienteDTO>> GetAllClientes()
        {
            Stream responseStream = await _httpClient.GetStreamAsync("https://localhost:44316/api/clientes");

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;

            return await JsonSerializer.DeserializeAsync<IEnumerable<ClienteDTO>>(responseStream,
                jsonSerializerOptions);
        }
    }
}