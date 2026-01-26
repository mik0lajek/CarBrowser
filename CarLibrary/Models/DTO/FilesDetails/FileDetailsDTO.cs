using CarLibrary.Models.DTO.FilesDetails;
using System.Text.Json.Serialization;

public class FileDetailsDTO
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("attributes")]
    public FileAttributesDTO Attributes { get; set; }
}
