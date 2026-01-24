using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class FuelInfo
{
    [JsonPropertyName("rodzaj-paliwa")]
    public string FuelType { get; set; }

    [JsonPropertyName("rodzaj-pierwszego-paliwa-alternatywnego")]
    public string FirstAlternativeFuelType { get; set; }

    [JsonPropertyName("rodzaj-drugiego-paliwa-alternatywnego")]
    public string SecondAlternativeFuelType { get; set; }
}
