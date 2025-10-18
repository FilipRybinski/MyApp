using Shared.Application.Abstractions.CQRS;
using Shared.Application.Commands.Prepare;
using Shared.Core.DTO;

namespace QueueMailer.Application.Commands.PrepareActivationEmail;

public sealed record ActivationEmail(IdentityDto Identity, string? Link) :PrepareEmail(Identity, Link), ICommand<TemplateDto>;