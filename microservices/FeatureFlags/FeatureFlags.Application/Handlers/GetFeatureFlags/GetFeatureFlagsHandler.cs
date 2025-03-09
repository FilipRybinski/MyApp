using FeatureFlags.Core.Configuration;
using Microsoft.Extensions.Options;

namespace FeatureFlags.Application.Handlers.GetFeatureFlags;

public class GetFeatureFlagsHandler(IOptions<FeatureFlagsConfiguration> featureFlags) : IGetFeatureFlagsHandler
{
    private readonly FeatureFlagsConfiguration FeatureFlags = featureFlags.Value;

    public FeatureFlagsConfiguration Handle()
    {
        return FeatureFlags;
    }
}