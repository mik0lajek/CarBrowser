using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CarLibrary.Models.DTO;

public class VehicleBasicDTO
{
    public string Id { get; set; }

    public string Brand { get; set; }
}
