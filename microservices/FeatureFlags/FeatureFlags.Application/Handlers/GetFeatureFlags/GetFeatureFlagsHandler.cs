using FeatureFlags.Core.DTO;
using Microsoft.Extensions.Options;

namespace FeatureFlags.Application.Handlers.GetFeatureFlags;

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