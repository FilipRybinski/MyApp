using Microsoft.Extensions.Options;
using MyApp.Core.Dictionary;
using MyApp.Core.DTO;
using MyApp.Core.Repositories;

namespace MyApp.Application.Handlers.GetFeatureFlags;

public class GetFeatureFlagsHandler : IGetFeatureFlagsHandler
{
    private readonly FeatureFlagsDto FeatureFlags;

    public GetFeatureFlagsHandler(IOptions<FeatureFlagsDto> featureFlags)
    {
        FeatureFlags = featureFlags.Value;
    }

    public FeatureFlagsDto Handle()
    {
        return FeatureFlags;
    }
}