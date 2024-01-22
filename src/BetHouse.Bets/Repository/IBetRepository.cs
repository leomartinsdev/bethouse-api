using BetHouse.Bets.DTO;
using BetHouse.Bets.Models;

namespace BetHouse.Bets.Repository;

public interface IBetRepository
{
    BetDTOResponse Post(BetDTORequest betRequest, string email);
    BetDTOResponse Get(int BetId, string email);
}