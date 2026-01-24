using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class OwnerInfo
{
    [JsonPropertyName("wlasciciel-gmina")]
    public string OwnerCommune { get; set; }

    [JsonPropertyName("wlasciciel-powiat")]
    public string OwnerDistrict { get; set; }

    [JsonPropertyName("wlasciciel-wojewodztwo")]
    public string OwnerVoivodeship { get; set; }

    [JsonPropertyName("wlasciciel-wojewodztwo-kod")]
    public string OwnerVoivodeshipCode { get; set; }
}
