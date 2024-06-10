using Microsoft.EntityFrameworkCore;
using MyApp.Core.Entities;
using MyApp.Core.Exceptions;
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

        if (!await IsTeamAlreadyCreated(user.Id))
        {
            throw new TeamNotAlreadyCreatedException(user.Id.ToString());
        }

        var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.OwnerId == user.Id && t.Name == name);

        if (team is null)
        {
            throw new TeamNotAlreadyCreatedException(user.Id.ToString());
        }

        var membersAndOwner = await _dbContext.Members.Where(m => m.TeamId == team.Id).ToListAsync();

        _dbContext.RemoveRange(membersAndOwner);
        _dbContext.Teams.Remove(team);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateMyTeam(string name)
    {
        var user = await _userRepository.GetCurrentUser();

        if (!await IsTeamAlreadyCreated(user.Id))
        {
            throw new TeamNotAlreadyCreatedException(user.Id.ToString());
        }

        var team = await _dbContext.Teams.FirstOrDefaultAsync(t => t.OwnerId == user.Id);
        team.UpdateTeamName(name);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsTeamAlreadyCreated(Guid userId) =>
        await _dbContext.Teams.AnyAsync(t => t.OwnerId == userId);

    public async Task<Team> GetMyTeam(Guid id) => await _dbContext.Teams.FirstOrDefaultAsync(t => t.OwnerId == id);
}