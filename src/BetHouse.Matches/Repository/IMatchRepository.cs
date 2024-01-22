using BetHouse.Matches.DTO;

namespace BetHouse.Matches.Repository;

public interface IMatchRepository
{
    IEnumerable<MatchDTOResponse> Get(bool MatchFinished);
}