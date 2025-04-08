using FeatureFlags.Core.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlags.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class FeatureFlagsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<FeatureFlagsConfiguration>> GetFeatureFlags()
    {
        return Ok(await sender.Send(new Application.Commands.Flags.FeatureFlags()));
    }
}