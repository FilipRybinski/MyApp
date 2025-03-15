using Identity.Core.Dictionary;
using Identity.Core.Entities;
using Identity.Infrastructure.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Identity.Infrastructure.DAL.Initializer;

internal sealed class DatabaseInitializer(IServiceProvider serviceProvider) : IHostedService
{
    public Task StartAsync(CancellationToken cancellationToken)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();
            dbContext.Database.Migrate();
            if (dbContext.Roles.Any()) return Task.CompletedTask;
            dbContext.Roles.AddRange(new List<Role>()
            {
                new Role(UserRoleDictionary.User),
                new Role(UserRoleDictionary.Moderator),
                new Role(UserRoleDictionary.Administrator)
            });
            dbContext.SaveChanges();
        }

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}