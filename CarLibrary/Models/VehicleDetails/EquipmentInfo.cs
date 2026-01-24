using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class EquipmentInfo
{
    [JsonPropertyName("hak")]
    public bool TowHook { get; set; }

    [JsonPropertyName("katalizator-pochlaniacz")]
    public bool CatalyticConverter { get; set; }

    [JsonPropertyName("kierownica-po-prawej-stronie")]
    public bool RightHandDrive { get; set; }

    [JsonPropertyName("kierownica-po-prawej-stronie-pierwotnie")]
    public bool OriginallyRightHandDrive { get; set; }

    [JsonPropertyName("wyposazenie-i-rodzaj-urzadzenia-radarowego")]
    public string RadarEquipmentType { get; set; }
}
