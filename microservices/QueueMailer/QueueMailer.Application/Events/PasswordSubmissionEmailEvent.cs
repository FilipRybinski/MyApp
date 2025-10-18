using Shared.Application.Events;

namespace QueueMailer.Application.Events;

public record PasswordSubmissionEmailEvent(string Email,string TemplateBody) : EmailEvent(Email, TemplateBody);