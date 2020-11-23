using System;
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
        private readonly string _baseAddress;
        private static readonly HttpClient HttpClient = new HttpClient();

        public HttpClienteCommunication(String baseAddress)
        {
            _baseAddress = baseAddress;
        }

        public async Task<IEnumerable<ClienteDTO>> GetAllClientes()
        {
            Stream responseStream = await HttpClient.GetStreamAsync($"{_baseAddress}/api/clientes");

            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.PropertyNameCaseInsensitive = true;

            return await JsonSerializer.DeserializeAsync<IEnumerable<ClienteDTO>>(responseStream,
                jsonSerializerOptions);
        }
    }
}