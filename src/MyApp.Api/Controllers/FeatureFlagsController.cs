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

    [Authorize]
    [HttpGet("[action]")]
    public async Task<FeatureFlagsDto> GetFeatureFlags()
    {
        return await _featureFlagsHandler.HandleAsync();
    }
}