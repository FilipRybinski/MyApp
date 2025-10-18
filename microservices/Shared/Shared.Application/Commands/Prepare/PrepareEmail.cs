using Shared.Core.DTO;

namespace Shared.Application.Commands.Prepare;

public record PrepareEmail(IdentityDto Identity, string? Link);