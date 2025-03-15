namespace FeatureFlags.Core.Configuration;

public sealed class FeatureFlagsConfiguration
{
    public bool Dashboard { get; init; }
    public bool Finance { get; init; }
    public bool Management { get; init; }
    public bool Marketplace { get; init; }
}