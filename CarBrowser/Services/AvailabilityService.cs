using Microsoft.Extensions.Configuration;
using System.Net.Http;

public class AvailabilityService
{
    private readonly HttpClient _client;
    private readonly string _serverEndpoint;
    private readonly string _cepikEndpoint;

    public AvailabilityService(IConfiguration config)
    {
        var baseUrl = config["CarGate:BaseUrl"];
        _serverEndpoint = config["CarGate:Endpoints:System:Server"];
        _cepikEndpoint = config["CarGate:Endpoints:System:Cepik"];

        _client = new HttpClient { BaseAddress = new Uri(baseUrl) };
    }

    public async Task<bool> CheckCarGateAsync()
    {
        try
        {
            var response = await _client.GetAsync(_serverEndpoint);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> CheckCepikAsync()
    {
        try
        {
            var response = await _client.GetAsync(_cepikEndpoint);
            return response.IsSuccessStatusCode;
        }
        catch
        {
            return false;
        }
    }
}
