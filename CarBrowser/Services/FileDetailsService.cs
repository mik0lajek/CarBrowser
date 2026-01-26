using CarLibrary.Models.DTO.FilesDetails;
using System.Net.Http;
using System.Text.Json;

namespace CarBrowser.Services
{
    public class FileDetailsService
    {
        private readonly HttpClient _client;
        private readonly string _detailsEndpoint;

        public FileDetailsService()
        {
            var config = App.Configuration;

            var baseUrl = config["CarGate:BaseUrl"];
            _detailsEndpoint = config["CarGate:Endpoints:System:FilesDetails"];

            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<FileDetailsDTO?> GetDetailsAsync(string id, CancellationToken ct = default)
        {


            var response = await _client.GetAsync($"{_detailsEndpoint}{id}", ct);


            if (!response.IsSuccessStatusCode)
            {
                return null;
            }


            var json = await response.Content.ReadAsStringAsync(ct);


            var result = JsonSerializer.Deserialize<FileDetailsDTO>(json);

            return result;
        }

    }
}
