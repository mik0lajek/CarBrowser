using System.Text.Json.Serialization;

namespace CarShared.Models.VehicleDetails;

public class RegistrationInfo
{
    [JsonPropertyName("rejestracja-gmina")]
    public string RegistrationCommune { get; set; }

    [JsonPropertyName("rejestracja-powiat")]
    public string RegistrationDistrict { get; set; }

    [JsonPropertyName("rejestracja-wojewodztwo")]
    public string RegistrationVoivodeship { get; set; }

    [JsonPropertyName("data-pierwszej-rejestracji")]
    public string FirstRegistrationDate { get; set; }

    [JsonPropertyName("data-pierwszej-rejestracjiwkraju")]
    public string FirstRegistrationInCountryDate { get; set; }

    [JsonPropertyName("data-pierwszej-rejestracji-za-granica")]
    public string FirstRegistrationAbroadDate { get; set; }

    [JsonPropertyName("data-ostatniej-rejestracji-w-kraju")]
    public string LastRegistrationInCountryDate { get; set; }

    [JsonPropertyName("data-wyrejestrowania-pojazdu")]
    public string DeregistrationDate { get; set; }

    [JsonPropertyName("data-wprowadzenia-danych")]
    public string DataEntryDate { get; set; }
}
