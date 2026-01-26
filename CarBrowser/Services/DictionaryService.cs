using CarLibrary.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarBrowser.Services
{
    public class DictionaryService
    {
        private readonly HttpClient _client;
        private readonly string _voivodeshipsEndpoint;

        public DictionaryService()
        {
            var config = App.Configuration;

            var baseUrl = config["CarGate:BaseUrl"];
            _voivodeshipsEndpoint = config["CarGate:Endpoints:System:Voivodeships"];

            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<DictionaryDTO>> GetProvincesAsync(CancellationToken ct = default)
        {
            var response = await _client.GetAsync(_voivodeshipsEndpoint, ct);

            if (!response.IsSuccessStatusCode)
                return new List<DictionaryDTO>();

            var json = await response.Content.ReadAsStringAsync(ct);
            return JsonSerializer.Deserialize<List<DictionaryDTO>>(json) ?? new List<DictionaryDTO>();
        }
    }

}
