using FeatureFlags.Core.DTO;
using Microsoft.Extensions.Options;

namespace FeatureFlags.Application.Handlers.GetFeatureFlags;

public class GetFeatureFlagsHandler(IOptions<FeatureFlagsDto> featureFlags) : IGetFeatureFlagsHandler
{
    private readonly FeatureFlagsDto FeatureFlags = featureFlags.Value;

    public FeatureFlagsDto Handle()
    {
        return FeatureFlags;
    }
}