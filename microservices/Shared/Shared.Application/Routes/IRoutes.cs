using Shared.Core.Configuration;

namespace Shared.Application.Routes;

public interface IRoutes
{
    RoutesConfiguration RoutesConfiguration { get; }
}