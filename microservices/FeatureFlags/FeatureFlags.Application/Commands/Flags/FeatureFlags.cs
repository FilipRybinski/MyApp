using FeatureFlags.Core.Configuration;
using Shared.Application.Abstractions.CQRS;

namespace FeatureFlags.Application.Commands.Flags;

public record FeatureFlags() : ICommand<FeatureFlagsConfiguration>;
