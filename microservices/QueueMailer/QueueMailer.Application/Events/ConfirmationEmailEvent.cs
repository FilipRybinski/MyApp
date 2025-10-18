using Shared.Application.Events;

namespace QueueMailer.Application.Events;

public sealed record ConfirmationEmailEvent(string Email,string TemplateBody) : EmailEvent(Email, TemplateBody);