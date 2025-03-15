using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Policies;

namespace TokenRegistry.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
[Authorize(Policy = AuthPolicies.Internal)]
public class TokenRegistryController(ILogger<TokenRegistryController> logger) : ControllerBase
{
    
    [HttpGet]
    public IActionResult Get()
    {
        return Ok();
    }
}