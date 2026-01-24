using System.Text.Json.Serialization;
using CarLibrary.Models.DTO;

namespace CarGate.Models.Cepik
{


    public class CepikDictionaryResponse
    {
        public CepikDictionaryData data { get; set; }
    }

    public class CepikDictionaryData
    {
        public CepikDictionaryAttributes attributes { get; set; }
    }

    public class CepikDictionaryAttributes
    {
        [JsonPropertyName("dostepne-rekordy-slownika")]
        public List<CepikDictionaryRecords> Records { get; set; }
    }

    public class CepikDictionaryRecords
    {
        [JsonPropertyName("klucz-slownika")]
        public string Code { get; set; }
        [JsonPropertyName("wartosc-slownika")]
        public string Name { get; set; }
    }

}
