using CarGate.Configuration;
using CarLibrary.Models.DTO;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CarGate.Services
{
    public class VehicleDetailsService
    {
        private readonly HttpClient _client;
        private readonly CepikEndpoints _endpoints;
        private readonly ILogger<VehicleDetailsService> _logger;

        public VehicleDetailsService(
            IHttpClientFactory factory,
            IOptions<CepikEndpoints> endpoints,
            ILogger<VehicleDetailsService> logger)
        {
            _client = factory.CreateClient("CepikClient");
            _endpoints = endpoints.Value;
            _logger = logger;
        }

        public async Task<string?> GetVehicleDetailsAsync(string id, CancellationToken ct = default)
        {
            try
            {
                var url = $"{_endpoints.Vehicles}/{id}";
                var response = await _client.GetAsync(url, ct);

                if (!response.IsSuccessStatusCode)
                    return null;

                var json = await response.Content.ReadAsStringAsync(ct);

                using var doc = JsonDocument.Parse(json);

                var attributes = doc.RootElement
                    .GetProperty("data")
                    .GetProperty("attributes");

                return attributes.GetRawText();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to load vehicle details");
                return null;
            }
        }

    }
}
