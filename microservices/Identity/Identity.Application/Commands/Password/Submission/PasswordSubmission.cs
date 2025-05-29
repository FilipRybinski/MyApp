using Shared.Application.Abstractions.CQRS;

namespace Identity.Application.Commands.Password.Submission;

public record PasswordSubmission(Guid Id,string Token,string Password) : ICommand;