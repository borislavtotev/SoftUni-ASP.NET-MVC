using SportSystem.App.Data.Repository;
using SportSystem.App.Model;

namespace SportSystem.App.Data.UnitOfWork
{
    public interface ISportSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Bet> Bets { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Match> Matches { get; }

        IRepository<Player> Players { get; }

        IRepository<Team> Teams { get; }

        IRepository<Vote> Votes { get; }

        void SaveChanges();
    }
}