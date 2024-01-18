using TryBets.Odds.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Globalization;

namespace TryBets.Odds.Repository;

public class OddRepository : IOddRepository
{
    protected readonly ITryBetsContext _context;
    public OddRepository(ITryBetsContext context)
    {
        _context = context;
    }

    public Match Patch(int MatchId, int TeamId, string BetValue)
    {
        string BetValueConverted = BetValue.Replace(',', '.');
        decimal BetValueDecimal = Decimal.Parse(BetValueConverted, CultureInfo.InvariantCulture);
        Match foundMatch = _context.Matches.FirstOrDefault(m => m.MatchId == MatchId)!;

        if (foundMatch.MatchTeamAId != TeamId && foundMatch.MatchTeamBId != TeamId)
        {
            return null;
        }

        if (foundMatch.MatchTeamAId == TeamId) foundMatch.MatchTeamAValue += BetValueDecimal;
        else foundMatch.MatchTeamBValue += BetValueDecimal;

        _context.Matches.Update(foundMatch);
        _context.SaveChanges();

        return new Match()
        {
            MatchId = foundMatch.MatchId,
            MatchDate = foundMatch.MatchDate,
            MatchTeamAId = foundMatch.MatchTeamAId,
            MatchTeamBId = foundMatch.MatchTeamBId,
            MatchTeamAValue = foundMatch.MatchTeamAValue,
            MatchTeamBValue = foundMatch.MatchTeamBValue,
            MatchFinished = foundMatch.MatchFinished,
            MatchWinnerId = foundMatch.MatchWinnerId,
            MatchTeamA = foundMatch.MatchTeamA,
            MatchTeamB = foundMatch.MatchTeamB,
            Bets = foundMatch.Bets
        };
    }
}