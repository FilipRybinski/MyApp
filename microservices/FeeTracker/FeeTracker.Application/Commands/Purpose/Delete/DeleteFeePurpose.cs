using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Purpose.Delete;

public record DeleteFeePurpose(Guid Id) : ICommand;