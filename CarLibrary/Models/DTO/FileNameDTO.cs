using System.Text.Json.Serialization;

namespace CarLibrary.Models.DTO;

public class FileNameDTO
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

}
