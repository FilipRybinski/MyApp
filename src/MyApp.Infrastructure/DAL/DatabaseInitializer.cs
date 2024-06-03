using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyApp.Core.Dictionary;
using MyApp.Core.Entities;

namespace MyApp.Infrastructure.DAL;

internal sealed class DatabaseInitializer: IHostedService
{
    private readonly IServiceProvider _serviceProvider;
    
    public DatabaseInitializer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    
    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<MyAppDbContext>();
            dbContext.Database.Migrate();
            if (!dbContext.Roles.Any())
            {
                dbContext.Roles.AddRange(new List<Role>()
                {
                    new Role(UserRoleDictionary.User),
                    new Role(UserRoleDictionary.Moderator),
                    new Role(UserRoleDictionary.Administrator)
                });
                dbContext.SaveChanges();
            }
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}