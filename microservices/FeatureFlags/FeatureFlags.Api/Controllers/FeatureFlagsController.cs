using FeatureFlags.Core.Configuration;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared.Core.Objects;

namespace FeatureFlags.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class FeatureFlagsController(ISender sender) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<Result<FeatureFlagsConfiguration>>> GetFeatureFlags()
    {
        return Result.MatchResponse(await sender.Send(new Application.Commands.Flags.FeatureFlags()));

    }
}