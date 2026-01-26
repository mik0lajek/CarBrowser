using CarBrowser.Tools;
using CarBrowser.ViewModels;
using CarLibrary.Models.DTO;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CarBrowser.Services
{

    public class VehicleSearchService
    {
        private readonly HttpClient _client;
        private readonly string _filterEndpoint;
        private readonly string _detailsEndpoint;

        public VehicleSearchService()
        {
            var config = App.Configuration;

            var baseUrl = config["CarGate:BaseUrl"];
            _filterEndpoint = config["CarGate:Endpoints:System:Filter"];
            _detailsEndpoint = config["CarGate:Endpoints:System:CarDetails"];


            _client = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
        }

        public async Task<List<VehicleBasicDTO>> SearchVehiclesAsync(
            string? voivodeship,
            DateTime? dateFrom,
            DateTime? dateTo,
            bool onlyRegistered,
            int limit)
        {
            var dto = new
            {
                voivodeship = voivodeship?.Split(" - ")[0],
                fromDate = dateFrom,
                toDate = dateTo,
                onlyRegistered = onlyRegistered,
                limit = limit
            };

            var json = JsonSerializer.Serialize(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_filterEndpoint, content);

            if (!response.IsSuccessStatusCode)
                return new List<VehicleBasicDTO>();

            var responseJson = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<VehicleBasicDTO>>(responseJson);

            if (result == null)
                return new List<VehicleBasicDTO>();

            return result
                .Select(x => new VehicleBasicDTO
                {
                    Id = x.Id,
                    Brand = x.Brand
                })
                .ToList();
        }

        public async Task<Dictionary<string, string>> GetVehicleDetailsAsync(string id)
        {
            var response = await _client.GetAsync($"{_detailsEndpoint}{id}");


            if (!response.IsSuccessStatusCode)
                return new Dictionary<string, string>();

            var json = await response.Content.ReadAsStringAsync();

            var dict = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            if (dict == null)
                return new Dictionary<string, string>();

            var result = new Dictionary<string, string>();

            foreach (var kv in dict)
            {
                var formattedKey = VehicleFormatter.FormatKey(kv.Key);
                var formattedValue = VehicleFormatter.FormatValue(kv.Value);

                result[formattedKey] = formattedValue;
            }

            return result;
        }

    }

}
