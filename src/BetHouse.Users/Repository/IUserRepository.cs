using BetHouse.Users.DTO;
using BetHouse.Users.Models;

namespace BetHouse.Users.Repository;

public interface IUserRepository
{
    User Post(User user);
    User Login(AuthDTORequest login);
}