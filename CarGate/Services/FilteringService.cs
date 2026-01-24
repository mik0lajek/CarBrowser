using CarGate.Configuration;
using CarGate.Models.Cepik;
using CarGate.Tools.QueryBuilders;
using CarLibrary.Models.DTO;
using Microsoft.Extensions.Options;
using System.Text;
using System.Text.Json;

namespace CarGate.Services;

public class FilteringService
{
    private readonly HttpClient _client;
    private readonly CepikEndpoints _endpoints;
    private readonly ILogger<FilteringService> _logger;

    public FilteringService(
        IHttpClientFactory factory,
        IOptions<CepikEndpoints> endpoints,
        ILogger<FilteringService> logger)
    {
        _client = factory.CreateClient("CepikClient");
        _endpoints = endpoints.Value;
        _logger = logger;
    }

    public async Task<List<VehicleBasicDTO>?> FilterVehiclesAsync(VehicleFiltersDTO f, CancellationToken ct = default)
    {
        try
        {
            var query = VehiclesQueryBuilder.Build(f);
            var url = $"{_endpoints.Vehicles}?{query}";

            var response = await _client.GetAsync(url, ct);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync(ct);

            var raw = JsonSerializer.Deserialize<CepikVehiclesResponse>(json);

            return raw?.data?
                .Select(v => new VehicleBasicDTO
                {
                    Id = v.id,
                    Brand = v.attributes.Brand
                })
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to filter vehicles");
            return null;
        }
    }


}
