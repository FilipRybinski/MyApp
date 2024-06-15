using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Exceptions;
using MyApp.Core.Repositories;

namespace MyApp.Infrastructure.DAL.Repositories;

internal class PostgresMemberRepository : IMemberRepository
{
    private readonly MyAppDbContext _dbContext;
    private readonly IUserRepository _userRepository;

    public PostgresMemberRepository(MyAppDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
    }


    public async Task InviteMembers(IEnumerable<Guid> members)
    {
        var owner = await _userRepository.GetCurrentUser();

        if (owner.Team is null)
        {
            throw new TeamNotAlreadyCreatedException(owner.Id.ToString());
        }

        var usersWithoutTeam = await _dbContext.Users.Include(m => m.Member)
            .Where(u => members.Contains(u.Id) && u.Member == default).ToListAsync();

        var newMembers = usersWithoutTeam.Select(u => new Member(u.Id, owner.Team.Id));

        await _dbContext.AddRangeAsync(newMembers);
        await _dbContext.SaveChangesAsync();
    }

    public async Task RemoveMembers(IEnumerable<Guid> members)
    {
        var owner = await _userRepository.GetCurrentUser();

        if (owner.Team is null)
        {
            throw new TeamNotAlreadyCreatedException(owner.Id.ToString());
        }

        var membersToRemove = _dbContext.Members.Where(m => members.Contains(m.UserId));
        _dbContext.Members.RemoveRange(membersToRemove);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<User>> GetAvailableMembers()
    {
        var user = await this._userRepository.GetCurrentUser();

        var result = await _dbContext.Users
            .Include(u => u.Member)
            .Where(m => m.Member == null && m.Id != user.Id).ToListAsync();

        return result;
    }


    public async Task<IEnumerable<User>> GetMyTeamMembers()
    {
        var owner = await _userRepository.GetCurrentUser();

        if (owner.Team is null)
        {
            throw new TeamNotAlreadyCreatedException(owner.Id.ToString());
        }

        return await _dbContext.Users.Include(u => u.Member).Where(m => m.Member.TeamId == owner.Team.Id).ToListAsync();
    }

    public async Task<IEnumerable<User>> FindAvailableMember(string name) =>
        await _dbContext.Users
            .Include(m => m.Member)
            .Where(u => (u.Name.ToLower().Contains(name.ToLower()) || u.Surname.ToLower().Contains(name.ToLower())) &&
                        u.Member == null)
            .ToListAsync();
}