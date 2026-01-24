using Microsoft.AspNetCore.Mvc;
using CarGate.Services;

namespace CarGate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DictionaryController : ControllerBase
{
    private readonly VoivodeshipDictionaryService _service;

    public DictionaryController(VoivodeshipDictionaryService service)
    {
        _service = service;
    }

    [HttpGet("wojewodztwa")]
    public async Task<IActionResult> GetVoivodeships(CancellationToken ct)
    {
        var result = await _service.GetVoivodeshipsAsync(ct);

        if (result == null)
            return NotFound(new { message = "CEPiK dictionary not available" });

        return Ok(result);
    }
}
