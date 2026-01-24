using CarShared.Models.VehicleDetails;
using System.Text.Json.Serialization;

namespace CarLibrary.Models.DTO;

public class VehicleDetailsDto
{
    public RegistrationInfo Registration { get; set; }
    public TechnicalInfo Technical { get; set; }
    public EmissionInfo Emissions { get; set; }
    public WeightInfo Weights { get; set; }
    public FuelInfo Fuel { get; set; }
    public OwnerInfo Owner { get; set; }
    public ProductionInfo Production { get; set; }
    public EquipmentInfo Equipment { get; set; }
}
