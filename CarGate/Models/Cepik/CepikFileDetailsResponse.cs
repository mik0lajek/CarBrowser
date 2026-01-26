using System.Text.Json.Serialization;

namespace CarGate.Models.Cepik
{
    public class CepikFileDetailsResponse
    {
        public CepikFileDetailsData data { get; set; }
    }

    public class CepikFileDetailsData
    {
        public string id { get; set; }
        public CepikFileDetailsAttributes attributes { get; set; }
    }

    public class CepikFileDetailsAttributes
    {
        [JsonPropertyName("url-do-pliku")]
        public string FileUrl { get; set; }

        [JsonPropertyName("url-do-metadanych-pliku")]
        public string MetadataUrl { get; set; }

        [JsonPropertyName("opis-zawartosci")]
        public string ContentDescription { get; set; }

        [JsonPropertyName("opis-formatu-pliku")]
        public string FileFormat { get; set; }

        [JsonPropertyName("typ-zasobu-bedacego-zawartoscia")]
        public string ResourceType { get; set; }

        [JsonPropertyName("data-utworzenia-pliku")]
        public string CreationDate { get; set; }
    }

}
