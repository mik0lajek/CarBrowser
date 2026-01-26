using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarLibrary.Models.DTO;

public class VehicleBasicDTO
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("brand")]
    public string Brand { get; set; }

    public string Display => $"{Brand} - {Id}";
}

