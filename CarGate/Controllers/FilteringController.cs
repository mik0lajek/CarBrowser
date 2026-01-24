using CarGate.Services;
using CarLibrary.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CarGate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilteringController : ControllerBase
{
    private readonly FilteringService _service;

    public FilteringController(FilteringService service)
    {
        _service = service;
    }

    [HttpPost("vehicleFilters")]
    public async Task<IActionResult> FilterVehicles([FromBody] VehicleFiltersDTO filters, CancellationToken ct)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _service.FilterVehiclesAsync(filters, ct);

        if (result == null)
            return NotFound(new { message = "CEPiK vehicle data not available" });

        return Ok(result);
    }

}
