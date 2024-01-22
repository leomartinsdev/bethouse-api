using BetHouse.Odds.Models;

namespace BetHouse.Odds.Repository;

public interface IOddRepository
{
    Match Patch(int MatchId, int TeamId, string BetValue);
}