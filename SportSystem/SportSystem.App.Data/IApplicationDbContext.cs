using System.Data.Entity;
using SportSystem.App.Model;

namespace SportSystem.App.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Bet> Bets { get; set; }
        DbSet<Comment> Comments { get; set; }
        DbSet<Match> Matches { get; set; }
        DbSet<Player> Players { get; set; }
        DbSet<Team> Teams { get; set; }
        DbSet<Vote> Votes { get; set; }
    }
}