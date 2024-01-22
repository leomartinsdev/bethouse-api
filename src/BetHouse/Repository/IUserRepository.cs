using BetHouse.DTO;
using BetHouse.Models;

namespace BetHouse.Repository;

public interface IUserRepository
{
    User Post(User user);
    User Login(AuthDTORequest login);
}