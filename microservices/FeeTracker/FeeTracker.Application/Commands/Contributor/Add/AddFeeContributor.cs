using Shared.Application.Abstractions.CQRS;

namespace FeeTracker.Application.Commands.Contributor.Add;

public record AddFeeContributor(
    string Name,
    string Surname,
    string Email
    ):ICommand;