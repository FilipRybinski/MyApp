using Shared.Application.Events;

namespace QueueMailer.Application.Events;

public sealed record ResetPasswordEmailEvent(string Email,string TemplateBody) : EmailEvent(Email, TemplateBody);