using Shared.Application.Abstractions.CQRS;

namespace Identity.Application.Commands.Password.Request;

public record ResetPasswordRequest(string Email) : ICommand;
