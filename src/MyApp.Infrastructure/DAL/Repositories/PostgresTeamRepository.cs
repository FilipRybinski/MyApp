using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Repositories;

namespace MyApp.Infrastructure.DAL.Repositories;

internal class PostgresTeamRepository : ITeamRepository
{
    private readonly MyAppDbContext _dbContext;
    private readonly IUserRepository _userRepository;

    public PostgresTeamRepository(MyAppDbContext dbContext, IUserRepository userRepository)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
    }

    public async Task OpenTeam(Team team)
    {
        await _dbContext.Teams.AddAsync(team);
        await _dbContext.SaveChangesAsync();
    }

    public async Task CloseTeam(string name)
    {
        var user = await _userRepository.GetCurrentUser();

        if (user.TeamId is null)
        {
            throw new Exception();
        }

        var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.OwnerId == user.Id && t.Name == name);

        if (team is null)
        {
            throw new Exception();
        }

        var membersAndOwner = await _dbContext.Users
            .Where(u => u.MemberId == team.Id || u.TeamId == team.Id).ToListAsync();

        foreach (var entity in membersAndOwner)
        {
            entity.SetMembershipToDefault();
        }

        _dbContext.Teams.Remove(team);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<Team> GetMyTeam(Guid id) => await _dbContext.Teams.FirstOrDefaultAsync(t => t.OwnerId == id);
}