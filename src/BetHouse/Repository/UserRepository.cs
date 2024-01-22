using BetHouse.Models;
using BetHouse.DTO;

namespace BetHouse.Repository;

public class UserRepository : IUserRepository
{
    protected readonly IBetHouseContext _context;
    public UserRepository(IBetHouseContext context)
    {
        _context = context;
    }

    public User Post(User user)
    {
        var userFound = _context.Users.Where(u => u.Email == user.Email);
        if (userFound.Count() > 0) throw new Exception("E-mail already used");
        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }
    public User Login(AuthDTORequest login)
    {
        var userFound = _context.Users.Where(user => user.Email == login.Email);
        if (userFound.Count() == 0) throw new Exception("Authentication failed");
        if (userFound.First().Password != login.Password) throw new Exception("Authentication failed");
        return userFound.FirstOrDefault()!;
    }
}