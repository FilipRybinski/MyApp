using Shared.Core.DTO;
using Shared.Domain.Abstractions;

namespace FeeTracker.Domain.Contributor;

public record FeeContributorCreatedDomainEvent(IdentityDto Identity) : IDomainEvent;