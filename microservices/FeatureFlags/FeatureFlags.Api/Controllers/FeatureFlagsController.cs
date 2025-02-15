using FeatureFlags.Application.Handlers.GetFeatureFlags;
using FeatureFlags.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlags.Api.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class FeatureFlagsController(IGetFeatureFlagsHandler featureFlagsHandler) : ControllerBase
{
    [HttpGet]
    public ActionResult<FeatureFlagsDto> GetFeatureFlags()
    {
        return featureFlagsHandler.Handle();
    }
}