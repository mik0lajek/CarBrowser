using CarGate.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarGate.Controllers
{
    [ApiController]
    [Route("api/vehicles")]
    public class VehicleDetailsController : ControllerBase
    {
        private readonly VehicleDetailsService _service;

        public VehicleDetailsController(VehicleDetailsService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetails(string id, CancellationToken ct)
        {
            var result = await _service.GetVehicleDetailsAsync(id, ct);

            if (result == null)
                return NotFound();

            return Content(result, "application/json");
        }

    }

}
