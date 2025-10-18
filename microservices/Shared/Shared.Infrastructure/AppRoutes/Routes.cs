using Microsoft.Extensions.Options;
using Shared.Application.Routes;
using Shared.Core.Configuration;

namespace Shared.Infrastructure.AppRoutes;

internal class Routes(IOptions<RoutesConfiguration> routesConfiguration) : IRoutes
{
    public RoutesConfiguration RoutesConfiguration => routesConfiguration.Value;
}