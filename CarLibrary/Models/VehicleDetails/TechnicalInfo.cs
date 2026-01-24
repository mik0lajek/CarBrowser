using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class TechnicalInfo
{
    [JsonPropertyName("marka")]
    public string Brand { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; }

    [JsonPropertyName("typ")]
    public string Type { get; set; }

    [JsonPropertyName("wariant")]
    public string Variant { get; set; }

    [JsonPropertyName("wersja")]
    public string Version { get; set; }

    [JsonPropertyName("moc-netto-silnika")]
    public int EngineNetPower { get; set; }

    [JsonPropertyName("pojemnosc-skokowa-silnika")]
    public int EngineCapacity { get; set; }

    [JsonPropertyName("liczba-osi")]
    public int AxlesCount { get; set; }

    [JsonPropertyName("max-rozstaw-kol")]
    public int MaxWheelTrack { get; set; }

    [JsonPropertyName("min-rozstaw-kol")]
    public int MinWheelTrack { get; set; }

    [JsonPropertyName("rozstaw-kol-osi-kierowanej-pozostalych-osi")]
    public string WheelTrackSteeredVsOther { get; set; }

    [JsonPropertyName("rodzaj-zwieszenia")]
    public string SuspensionType { get; set; }

    [JsonPropertyName("rodzaj-tabliczki-znamionowej")]
    public string NameplateType { get; set; }
}
