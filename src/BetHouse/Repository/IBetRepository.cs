using BetHouse.DTO;
using BetHouse.Models;

namespace BetHouse.Repository;

public interface IBetRepository
{
    BetDTOResponse Post(BetDTORequest betRequest, string email);
    BetDTOResponse Get(int BetId, string email);
}