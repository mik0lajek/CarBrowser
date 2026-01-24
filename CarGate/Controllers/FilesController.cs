using CarGate.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarGate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilesController : ControllerBase
{
    private readonly FilesService _service;

    public FilesController(FilesService service)
    {
        _service = service;
    }

    [HttpGet("getFilesDescription")]
    public async Task<IActionResult> GetFilesDescription(CancellationToken ct)
    {
        var result = await _service.GetFilesAsync(ct);

        if (result == null)
            return NotFound(new { message = "CEPiK files not available" });

        return Ok(result);
    }
}
