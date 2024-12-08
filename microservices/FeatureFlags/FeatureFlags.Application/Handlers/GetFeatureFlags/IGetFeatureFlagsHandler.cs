using FeatureFlags.Core.DTO;

namespace FeatureFlags.Application.Handlers.GetFeatureFlags;

public interface IGetFeatureFlagsHandler
{
    FeatureFlagsDto Handle();
}