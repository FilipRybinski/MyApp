using Shared.Domain.Abstractions;

namespace Identity.Domain.Identity;

public record UserIdentitySignUpDomainEvent(Guid Id, string Email) : IDomainEvent;
