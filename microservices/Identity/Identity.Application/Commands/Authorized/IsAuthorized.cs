using Identity.Core.DTO;
using MediatR;
using Shared.Application.Abstractions.CQRS;

namespace Identity.Application.Commands.Authorized;

public record IsAuthorized(): ICommand<IdentityDto?>;