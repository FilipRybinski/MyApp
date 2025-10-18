using Shared.Core.DTO;
using Shared.Domain.Abstractions;

namespace Identity.Domain.Identity;

public record UserIdentityPasswordSubmissionDomainEvent(IdentityDto Identity) : IDomainEvent;
