using BetHouse.DTO;

namespace BetHouse.Repository;

public class TeamRepository : ITeamRepository
{
    protected readonly IBetHouseContext _context;
    public TeamRepository(IBetHouseContext context)
    {
        _context = context;
    }

    public IEnumerable<TeamDTOResponse> Get()
    {
        return _context.Teams.Select(t => new TeamDTOResponse {
            TeamId = t.TeamId,
            TeamName = t.TeamName
        }).ToList();
    }
}