using Identity.Application.Abstractions.Security;
using Identity.Core.Repositories;
using Identity.Domain.Identity;
using Identity.Domain.Roles;
using Identity.Infrastructure.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Application.Providers.Identity;

namespace Identity.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserIdentityRepository(
    IdentityDbContext dbContext,
    IIdentityProvider identityProvider,
    IMediator mediator)
    : IUserIdentityRepository
{
    public async Task<UserIdentity?> GetSessionUserIdentityAsync() =>
        await dbContext.Identities.FirstOrDefaultAsync(u => u.Id == identityProvider.ExtractUserIdentityIdentifier());

    public async Task<UserIdentity?> GetUserIdentityByIdAsync(Guid id) =>
        await dbContext.Identities.FirstOrDefaultAsync(u=>u.Id == id);

    public async Task<UserIdentity> AddUserIdentityAsync(UserIdentity user)
    {
        dbContext.Identities.Add(user);
        await ExecuteIdentityDomainEvent(user);
        await dbContext.SaveChangesAsync();
        await dbContext.Entry(user).ReloadAsync();
        return user;
    }

    public async Task<UserIdentity?> GetUserIdentityByEmailAsync(string email) =>
        await dbContext.Identities.Include<UserIdentity, Role>(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

    public async Task UserIdentityActivationAsync(UserIdentity userIdentity)
    {
        userIdentity.Activate();
        await ExecuteIdentityDomainEvent(userIdentity);
        await dbContext.SaveChangesAsync();
    }

    public async Task UserIdentityPasswordSubmissionAsync(UserIdentity userIdentity, string password)
    {
        userIdentity.PasswordSubmission(password);
        await ExecuteIdentityDomainEvent(userIdentity);
        await dbContext.SaveChangesAsync();
    }


    public bool IsEmailAlreadyExists(string email) => dbContext.Identities.Any(u => u.Email == email);

    public bool IsUserNameAlreadyExists(string username) => dbContext.Identities.Any(u => u.Username == username);

    private async Task ExecuteIdentityDomainEvent(UserIdentity userIdentity)
    {
        foreach (var domainEvent in userIdentity.DomainEvents)
        {
            await mediator.Publish(domainEvent);
        }
        userIdentity.DomainEvents.Clear();
    }
}