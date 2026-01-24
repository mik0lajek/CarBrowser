using CarGate.Configuration;
using CarGate.Models;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace CarGate.Services
{
    public class CepikSystemService
    {
        private readonly HttpClient _client;
        private readonly ILogger<CepikSystemService> _logger;
        private readonly CepikEndpoints _endpoints;

        public CepikSystemService(
            IHttpClientFactory httpClientFactory,
            ILogger<CepikSystemService> logger,
            IOptions<CepikEndpoints> endpoints)
        {
            _client = httpClientFactory.CreateClient("CepikClient");
            _logger = logger;
            _endpoints = endpoints.Value;
        }

        public async Task<VersionResponse?> GetCepikStatusAsync(CancellationToken ct = default)
        {
            var endpoints = new[] { _endpoints.Version, _endpoints.VersionV1 };

            foreach (var endpoint in endpoints)
            {
                try
                {
                    var response = await _client.GetAsync(endpoint, ct);

                    if (!response.IsSuccessStatusCode)
                        continue;

                    var json = await response.Content.ReadAsStringAsync(ct);

                    var raw = JsonSerializer.Deserialize<VersionResponse>(json);

                    return raw;
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, $"CEPiK endpoint failed: {endpoint}");
                }
            }

            return null;
        }

    }

}
