using Shared.Application.Abstractions.CQRS;

namespace Identity.Application.Commands.Activation;

public record ActivationAction(Guid Id, string Token) : ICommand;