using CarLibrary.Models.DTO;
using System.Net.Http;
using System.Text.Json;

namespace CarBrowser.Services
{
    public class FilesListService
    {
        private readonly HttpClient _client;
        private readonly string _filesListEndpoint;

        public FilesListService()
        {
            var config = App.Configuration;

            var baseUrl = config["CarGate:BaseUrl"];
            _filesListEndpoint = config["CarGate:Endpoints:System:FilesList"];

            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<FileNameDTO>> GetFilesAsync()
        {
            var response = await _client.GetAsync(_filesListEndpoint);

            if (!response.IsSuccessStatusCode)
                return new List<FileNameDTO>();

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<List<FileNameDTO>>(json);

            return result ?? new List<FileNameDTO>();
        }
    }
}
