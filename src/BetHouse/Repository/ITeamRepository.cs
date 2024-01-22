using BetHouse.DTO;

namespace BetHouse.Repository;

public interface ITeamRepository
{
    IEnumerable<TeamDTOResponse> Get();    
}