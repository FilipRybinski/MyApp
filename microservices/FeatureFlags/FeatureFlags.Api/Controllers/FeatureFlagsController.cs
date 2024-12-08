using FeatureFlags.Application.Handlers.GetFeatureFlags;
using FeatureFlags.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace FeatureFlags.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureFlagsController : ControllerBase
{
    private readonly IGetFeatureFlagsHandler _featureFlagsHandler;

    public FeatureFlagsController(IGetFeatureFlagsHandler featureFlagsHandler)
    {
        _featureFlagsHandler = featureFlagsHandler;
    }
    
    [HttpGet("[action]")]
    public ActionResult<FeatureFlagsDto> GetFeatureFlags()
    {
        return _featureFlagsHandler.Handle();
    }
}