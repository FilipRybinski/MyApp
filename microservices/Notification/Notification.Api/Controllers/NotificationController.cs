using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Policies;

namespace Notification.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize(Policy = AuthPolicies.Internal)]
public class NotificationController : ControllerBase
{
    private readonly ILogger<NotificationController> _logger;

    public NotificationController(ILogger<NotificationController> logger)
    {
        _logger = logger;
    }
}