using Identity.Application.Abstractions.Security;
using Identity.Core.Repositories;
using Identity.Domain.Identity;
using Identity.Domain.Role;
using Identity.Infrastructure.DAL.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Identity.Infrastructure.DAL.Repositories;

internal sealed class PostgresUserIdentityRepository(
    IdentityDbContext dbContext,
    IHttpContextTokenService contextTokenService,
    IMediator mediator)
    : IUserIdentityRepository
{
    public async Task<UserIdentity?> GetSessionUserIdentityAsync() =>
        await dbContext.Identities.FirstOrDefaultAsync<UserIdentity>(u => u.Id == contextTokenService.ExtractUserIdentityIdentifier());

    public async Task<UserIdentity> AddUserIdentityAsync(UserIdentity user)
    {
        dbContext.Identities.Add(user);
        await mediator.Publish(user.DomainEvents.LastOrDefault());
        await dbContext.SaveChangesAsync();
        await dbContext.Entry(user).ReloadAsync();
        return user;
    }

    public async Task<UserIdentity?> GetUserIdentityByEmailAsync(string email) =>
        await dbContext.Identities.Include<UserIdentity, Role>(u => u.Role).FirstOrDefaultAsync(u => u.Email == email);

    public bool IsEmailAlreadyExists(string email) => dbContext.Identities.Any<UserIdentity>(u => u.Email == email);

    public bool IsUserNameAlreadyExists(string username) => dbContext.Identities.Any<UserIdentity>(u => u.Username == username);
}