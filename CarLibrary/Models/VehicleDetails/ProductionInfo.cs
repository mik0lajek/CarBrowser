using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class ProductionInfo
{
    [JsonPropertyName("nazwa-producenta")]
    public string ManufacturerName { get; set; }

    [JsonPropertyName("sposob-produkcji")]
    public string ProductionMethod { get; set; }

    [JsonPropertyName("rok-produkcji")]
    public string ProductionYear { get; set; }

    [JsonPropertyName("pochodzenie-pojazdu")]
    public string VehicleOrigin { get; set; }
}
