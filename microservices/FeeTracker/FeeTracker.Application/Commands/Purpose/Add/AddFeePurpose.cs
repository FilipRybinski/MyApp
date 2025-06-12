using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Purpose.Add;

public record AddFeePurpose(
    string Title,
    DateTime StartDate,
    DateTime EndDate,
    decimal Amount
    ) : ICommand;