using System.Text.Json.Serialization;

namespace CarGate.Models;

public class VersionResponse
{
    [JsonPropertyName("dateMod")]
    public string DateMod { get; set; }

    [JsonPropertyName("deprecated")]
    public string Deprecated { get; set; }

    [JsonPropertyName("major")]
    public string Major { get; set; }

    [JsonPropertyName("minor")]
    public string Minor { get; set; }

    [JsonPropertyName("patch")]
    public string Patch { get; set; }
}
