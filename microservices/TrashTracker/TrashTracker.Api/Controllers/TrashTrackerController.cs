using Microsoft.AspNetCore.Mvc;

namespace TrashTracker.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TrashTrackerController(ILogger<TrashTrackerController> logger) : ControllerBase
{
    private readonly ILogger<TrashTrackerController> _logger = logger;
}