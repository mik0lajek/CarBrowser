using System.Text.Json;
using CarGate.Configuration;
using CarGate.Models.Cepik;
using CarLibrary.Models.DTO;
using Microsoft.Extensions.Options;

namespace CarGate.Services;

public class FilesService
{
    private readonly HttpClient _client;
    private readonly CepikEndpoints _endpoints;
    private readonly ILogger<FilesService> _logger;

    public FilesService(
        IHttpClientFactory factory,
        IOptions<CepikEndpoints> endpoints,
        ILogger<FilesService> logger)
    {
        _client = factory.CreateClient("CepikClient");
        _endpoints = endpoints.Value;
        _logger = logger;
    }

    public async Task<List<FileNameDTO>?> GetFilesAsync(CancellationToken ct = default)
    {
        try
        {
            var response = await _client.GetAsync(_endpoints.Files, ct);

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync(ct);

            var raw = JsonSerializer.Deserialize<CepikFilesResponse>(json);

            if (raw?.data == null)
                return null;

            return raw.data
                .Select(f =>
                {
                    var fileDesc = Path.GetFileName(f.attributes.FileDesc);

                    return new FileNameDTO
                    {
                        Name = $"{fileDesc} - ({f.id})"
                    };
                })
                .ToList();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to fetch CEPiK files");
            return null;
        }
    }
}
