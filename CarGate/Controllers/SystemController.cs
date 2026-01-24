using Microsoft.AspNetCore.Mvc;
using CarGate.Services;

namespace CarGate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemController : ControllerBase
    {
        private readonly CepikSystemService _systemService;

        public SystemController(CepikSystemService systemService)
        {
            _systemService = systemService;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("CarGate is running");
        }

        [HttpGet("checkCepikStatus")]
        public async Task<IActionResult> CheckCepikStatus(CancellationToken ct)
        {
            var version = await _systemService.GetCepikStatusAsync(ct);

            if (version == null)
                return NotFound(new { message = "CEPiK server is not responding" });

            return Ok(new
            {
                version = $"{version.Major}.{version.Minor}.{version.Patch}"
            });
        }
    }
}
