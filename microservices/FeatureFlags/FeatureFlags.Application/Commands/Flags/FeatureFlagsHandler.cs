using FeatureFlags.Core.Configuration;
using Microsoft.Extensions.Options;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;

namespace FeatureFlags.Application.Commands.Flags;

public sealed class FeatureFlagsHandler(IOptions<FeatureFlagsConfiguration> featureFlags) : ICommandHandler<FeatureFlags,FeatureFlagsConfiguration>
{
    private readonly FeatureFlagsConfiguration FeatureFlags = featureFlags.Value;

    public async Task<Result<FeatureFlagsConfiguration>> Handle(FeatureFlags request, CancellationToken cancellationToken)
    {
        return FeatureFlags;
    }
}