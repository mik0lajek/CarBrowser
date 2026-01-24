using System.Text.Json.Serialization;

namespace CarGate.Models.Cepik
{


    public class CepikVehiclesResponse
    {
        public List<CepikVehicleData> data { get; set; }
    }

    public class CepikVehicleData
    {
        public string id { get; set; }
        public CepikVehicleAttributes attributes { get; set; }
    }

    public class CepikVehicleAttributes
    {
        [JsonPropertyName("marka")]
        public string Brand { get; set; }
    }

}
