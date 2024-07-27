using Microsoft.AspNetCore.Mvc;

namespace Integration.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class IntegrationController : ControllerBase
{
    private readonly ILogger<IntegrationController> _logger;

    public IntegrationController(ILogger<IntegrationController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        return Ok();
    }
}