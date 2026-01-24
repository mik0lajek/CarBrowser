using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class WeightInfo
{
    [JsonPropertyName("dopuszczalna-ladownosc")]
    public int PermissiblePayload { get; set; }

    [JsonPropertyName("maksymalna-ladownosc")]
    public int MaxPayload { get; set; }

    [JsonPropertyName("dopuszczalna-masa-calkowita")]
    public int PermissibleGrossWeight { get; set; }

    [JsonPropertyName("maksymalna-masa-calkowita")]
    public int MaxGrossWeight { get; set; }

    [JsonPropertyName("dopuszczalna-masa-calkowita-zespolu-pojazdow")]
    public int PermissibleGrossWeightOfVehicleSet { get; set; }

    [JsonPropertyName("masa-wlasna")]
    public int CurbWeight { get; set; }

    [JsonPropertyName("masa-pojazdu-gotowego-do-jazdy")]
    public int ReadyToDriveWeight { get; set; }

    [JsonPropertyName("dopuszczalny-nacisk-osi")]
    public int PermissibleAxleLoad { get; set; }

    [JsonPropertyName("maksymalny-nacisk-osi")]
    public int MaxAxleLoad { get; set; }

    [JsonPropertyName("avg-rozstaw-kol")]
    public int AvgWheelTrack { get; set; }
}
