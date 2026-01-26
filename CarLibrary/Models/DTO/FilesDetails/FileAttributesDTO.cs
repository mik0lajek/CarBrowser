using System.Text.Json.Serialization;

namespace CarLibrary.Models.DTO.FilesDetails
{
    public class FileAttributesDTO
    {
        [JsonPropertyName("fileUrl")]
        public string FileUrl { get; set; }

        [JsonPropertyName("metadataUrl")]
        public string MetadataUrl { get; set; }

        [JsonPropertyName("contentDescription")]
        public string ContentDescription { get; set; }

        [JsonPropertyName("fileFormatDescription")]
        public string FileFormatDescription { get; set; }

        [JsonPropertyName("resourceType")]
        public string ResourceType { get; set; }

        [JsonPropertyName("fileCreationDate")]
        public string FileCreationDate { get; set; }
    }
}
