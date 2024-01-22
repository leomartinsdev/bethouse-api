using BetHouse.Odds.Models;
using Microsoft.EntityFrameworkCore;

namespace BetHouse.Odds.Repository;

public interface IBetHouseContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Team> Teams { get; set;}
    public DbSet<Match> Matches { get; set;}
    public DbSet<Bet> Bets { get; set; }
    public int SaveChanges();
}