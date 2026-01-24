using System.Text.Json;
using CarGate.Configuration;
using CarGate.Models.Cepik;
using CarLibrary.Models.DTO;
using Microsoft.Extensions.Options;

namespace CarGate.Services;

public class VoivodeshipDictionaryService
{
    private readonly HttpClient _client;
    private readonly ILogger<VoivodeshipDictionaryService> _logger;
    private readonly CepikEndpoints _endpoints;

    public VoivodeshipDictionaryService(
        IHttpClientFactory factory,
        ILogger<VoivodeshipDictionaryService> logger,
        IOptions<CepikEndpoints> endpoints)
    {
        _client = factory.CreateClient("CepikClient");
        _logger = logger;
        _endpoints = endpoints.Value;
    }

    public async Task<List<DictionaryDTO>?> GetVoivodeshipsAsync(CancellationToken ct = default)
    {
        try
        {
            var endpoint = _endpoints.Dictionaries.Voivodeships;

            var response = await _client.GetAsync(endpoint, ct);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync(ct);

            var raw = JsonSerializer.Deserialize<CepikDictionaryResponse>(json);

            var records = raw?.data?.attributes?.Records;

            if (records == null)
                return null;

            return records.Select(r => new DictionaryDTO
            {
                Code = r.Code,
                Name = r.Name 
            }).ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to load voivodeships dictionary");
            return null;
        }
    }

}
