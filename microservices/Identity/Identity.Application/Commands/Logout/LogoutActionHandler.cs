using Shared.Application.Abstractions.CQRS;
using Shared.Core.Objects;
using IHttpContextTokenService = Identity.Application.Abstractions.Security.IHttpContextTokenService;

namespace Identity.Application.Commands.Logout;

public sealed class LogoutActionHandler(IHttpContextTokenService httpContextTokenService) : ICommandHandler<LogoutAction>
{
    public async Task<Result> Handle(LogoutAction request, CancellationToken cancellationToken)
    {
        httpContextTokenService.Remove();
        return Result.Success();
    }
}