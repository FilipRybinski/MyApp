using Microsoft.AspNetCore.Mvc;

namespace Notification.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ILogger<NotificationController> logger)
    {
        _logger = logger;
    }
}