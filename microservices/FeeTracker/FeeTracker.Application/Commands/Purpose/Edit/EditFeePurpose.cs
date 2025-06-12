using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Purpose.Edit;

public record EditFeePurpose( Guid Id, string Title , DateTime StartDate, DateTime EndDate) : ICommand;
