using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Shared.Infrastructure.Configuration;

public static class Extensions
{
    public static IConfigurationBuilder AddSharedConfiguration(this IConfigurationBuilder builder,IHostEnvironment env)
    {
        
        var settings = env.EnvironmentName switch
        {
            "Production" => "sharedSettings.json",
            "Development" => "sharedSettings.Development.json",
            _ => "sharedSettings.Development.json"
        };

        builder.AddJsonFile(Path.Combine(AppContext.BaseDirectory,settings), true, true);
        
        return builder;
    }
}