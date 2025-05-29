using Identity.Core.DTO;
using MediatR;
using Shared.Application.Abstractions.CQRS;
using Shared.Core.DTO;

namespace Identity.Application.Commands.Authorized;

public record IsAuthorized(): ICommand<IdentityDto?>;