using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Abstractions;
using MyApp.Core.DTO;

namespace MyApp.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class FeatureFlagsController : ControllerBase
{
    private readonly IEmptyQueryHandler<FeatureFlagsDto> _featureFlagsHandler;

    public FeatureFlagsController(IEmptyQueryHandler<FeatureFlagsDto> featureFlagsHandler)
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