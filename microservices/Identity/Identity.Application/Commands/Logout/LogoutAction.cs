using MediatR;
using Shared.Application.Abstractions.CQRS;

namespace Identity.Application.Commands.Logout;

public record LogoutAction() : ICommand<bool>;
