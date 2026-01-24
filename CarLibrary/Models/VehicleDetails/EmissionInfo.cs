using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class EmissionInfo
{
    [JsonPropertyName("poziom-emisji-co2")]
    public int Co2Emission { get; set; }

    [JsonPropertyName("poziom-emisji-co2-pierwsze-paliwo-alternatwne")]
    public int Co2EmissionFirstAltFuel { get; set; }

    [JsonPropertyName("poziom-emisji-co2-drugie-paliwo-alternatwne")]
    public int Co2EmissionSecondAltFuel { get; set; }

    [JsonPropertyName("redukcja-emisji-spalin")]
    public int EmissionReduction { get; set; }

    [JsonPropertyName("avg-zuzycie-paliwa")]
    public int AvgFuelConsumption { get; set; }
}
