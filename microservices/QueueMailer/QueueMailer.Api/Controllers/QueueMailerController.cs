using Microsoft.AspNetCore.Mvc;

namespace QueueMailer.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class QueueMailerController(ILogger<QueueMailerController> logger) : ControllerBase
{

    private readonly ILogger<QueueMailerController> _logger = logger;
}