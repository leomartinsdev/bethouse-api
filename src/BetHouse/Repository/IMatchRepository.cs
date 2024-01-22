using BetHouse.DTO;

namespace BetHouse.Repository;

public interface IMatchRepository
{
    IEnumerable<MatchDTOResponse> Get(bool MatchFinished);
}