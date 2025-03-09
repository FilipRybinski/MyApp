using FeatureFlags.Core.Configuration;

namespace FeatureFlags.Application.Handlers.GetFeatureFlags;

public interface IGetFeatureFlagsHandler
{
    FeatureFlagsConfiguration Handle();
}