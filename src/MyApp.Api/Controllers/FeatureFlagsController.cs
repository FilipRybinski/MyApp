using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Handlers.GetFeatureFlags;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

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