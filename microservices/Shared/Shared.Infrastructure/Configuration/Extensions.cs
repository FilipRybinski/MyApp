using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Shared.Infrastructure.Configuration;

public static class Extensions
{
    private const string ProductionEnvironment = "Production";
    private const string DevelopmentEnvironment = "Development";
    private const string SettingsProduction = "sharedSettings.json";
    private const string SettingsDevelopment = "sharedSettings.Development.json";
    
    public static IConfigurationBuilder AddSharedConfiguration(this IConfigurationBuilder builder,IHostEnvironment env)
    {
        
        var settings = env.EnvironmentName switch
        {
            ProductionEnvironment => SettingsProduction,
            DevelopmentEnvironment => SettingsDevelopment,
            _ => SettingsDevelopment
        };

        builder.AddJsonFile(Path.Combine(AppContext.BaseDirectory,settings), true, true);
        
        return builder;
    }
}