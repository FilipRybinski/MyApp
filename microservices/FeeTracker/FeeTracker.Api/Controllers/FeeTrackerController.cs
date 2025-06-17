using Microsoft.AspNetCore.Mvc;

namespace FeeTracker.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FeeTrackerController() : ControllerBase
{

    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}