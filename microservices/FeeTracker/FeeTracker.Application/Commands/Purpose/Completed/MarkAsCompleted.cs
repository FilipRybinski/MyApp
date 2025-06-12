using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Purpose.Completed;

public record MarkAsCompleted(Guid Id) : ICommand;