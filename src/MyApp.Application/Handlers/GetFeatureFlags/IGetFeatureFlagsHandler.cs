using MyApp.Core.DTO;

namespace MyApp.Application.Handlers.GetFeatureFlags;

public interface IGetFeatureFlagsHandler
{
    FeatureFlagsDto Handle();
}