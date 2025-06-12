using Shared.Application.Events;

namespace QueueMailer.Application.Events;

public sealed record CreateContributorEmailEvent(string Email,string TemplateBody) : EmailEvent(Email, TemplateBody);