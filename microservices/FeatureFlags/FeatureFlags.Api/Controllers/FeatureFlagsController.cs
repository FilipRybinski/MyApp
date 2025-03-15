using FeatureFlags.Application.Handlers.GetFeatureFlags;
using FeatureFlags.Core.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlags.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public sealed class FeatureFlagsController(IGetFeatureFlagsHandler featureFlagsHandler) : ControllerBase
{
    [HttpGet]
    public ActionResult<FeatureFlagsConfiguration> GetFeatureFlags()
    {
        return featureFlagsHandler.Handle();
    }
}