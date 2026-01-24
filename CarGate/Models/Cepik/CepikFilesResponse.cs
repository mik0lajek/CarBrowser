using System.Text.Json.Serialization;

namespace CarGate.Models.Cepik;

public class CepikFilesResponse
{
    public List<CepikFileData> data { get; set; }
}

public class CepikFileData
{
    public string id { get; set; }
    public CepikFileAttributes attributes { get; set; }
}

public class CepikFileAttributes
{
    [JsonPropertyName("opis-zawartosci")]
    public string FileDesc { get; set; }
}
