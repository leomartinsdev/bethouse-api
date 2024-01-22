using BetHouse.Matches.DTO;

namespace BetHouse.Matches.Repository;

public interface ITeamRepository
{
    IEnumerable<TeamDTOResponse> Get();    
}