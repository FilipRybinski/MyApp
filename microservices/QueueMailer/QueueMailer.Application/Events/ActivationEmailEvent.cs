using Shared.Application.Events;

namespace QueueMailer.Application.Events;

public sealed record ActivationEmailEvent(string Email,string TemplateBody) : EmailEvent(Email, TemplateBody);