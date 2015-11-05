using System.Web;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SportSystem.App.Model;

namespace SportSystem.App.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SportSystem.App.Data.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            if (!context.Teams.Any())
            {
                this.SeedTeams(context);
            }

            if (!context.Matches.Any())
            {
                this.SeedMatches(context);
            }

            if (!context.Players.Any())
            {
                this.SeedPlayers(context);
            }

            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }

            if (!context.Comments.Any())
            {
                this.SeedComments(context);
            }

            if (!context.Bets.Any())
            {
                this.SeedBets(context);
            }

            if (!context.Votes.Any())
            {
                this.SeedVotes(context);
            }
            
        }

        private void SeedVotes(ApplicationDbContext context)
        {
            Vote[] votes = new Vote[]
            {
                new Vote()
                {
                    Team = context.Teams.FirstOrDefault(t => t.Name == "Bayern Munich"),
                    User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                },
               new Vote()
                {
                    Team = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                    User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com")
                },
                new Vote()
                {
                    Team = context.Teams.FirstOrDefault(t => t.Name == "Bayern Munich"),
                    User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net")
                },
            };

            foreach (var vote in votes)
            {
                context.Votes.Add(vote);
            }
        }

        private void SeedBets(ApplicationDbContext context)
        {
            Bet[] bets = new Bet[]
            {
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
                    HomeBet = 30.00m,
                    AwayBet = 0.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
                    HomeBet = 0.00m,
                    AwayBet = 50.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
                    HomeBet = 0.00m,
                    AwayBet = 120.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "FC Barcelona" && m.AwayTeam.Name == "Manchester City"),
                    HomeBet = 120.00m,
                    AwayBet = 0.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                    HomeBet = 500.00m,
                    AwayBet = 0.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                    HomeBet = 50.00m,
                    AwayBet = 0.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                    HomeBet = 0.00m,
                    AwayBet = 20.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com"),
                },
                new Bet()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "FC Barcelona"),
                    HomeBet = 0.00m,
                    AwayBet = 220.00m,
                    User = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com"),
                },
            };

            foreach (var bet in bets)
            {
                context.Bets.Add(bet);
            }

            context.SaveChanges();


        }

        private void SeedComments(ApplicationDbContext context)
        {
            Comment[] comments = new Comment[]
            {
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                    Content = "The best match this summer!",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                    CreationDateTime = DateTime.Now
                },
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Bayern Munich" && m.AwayTeam.Name == "Manchester United F.C."),
                    Content = "The good football this evening.",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com"),
                    CreationDateTime = DateTime.Now
                },
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "FC Barcelona" && m.AwayTeam.Name == "Manchester City"),
                    Content = "Barca!",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com"),
                    CreationDateTime = DateTime.Now
                },
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Real Madrid" && m.AwayTeam.Name == "Manchester City"),
                    Content = "Real forever!",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                    CreationDateTime = DateTime.Now
                },
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Real Madrid" && m.AwayTeam.Name == "Manchester City"),
                    Content = "Real, real, real",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                    CreationDateTime = DateTime.Now
                },
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Real Madrid" && m.AwayTeam.Name == "Manchester City"),
                    Content = "Real again :)",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "alex@usa.net"),
                    CreationDateTime = DateTime.Now
                },
                new Comment()
                {
                    Match = context.Matches.FirstOrDefault(m => m.HomeTeam.Name == "Chelsea" && m.AwayTeam.Name == "Real Madrid"),
                    Content = "Chelsea champion!",
                    OwnerUser = context.Users.FirstOrDefault(u => u.UserName == "tanya@gmail.com"),
                    CreationDateTime = DateTime.Now
                },
            };

            foreach (var comment in comments)
            {
                context.Comments.Add(comment);
            }

            context.SaveChanges();
        }

        private void SeedUsers(ApplicationDbContext context)
        {
            User alex = new User()
            {
                UserName = "alex@usa.net"
            };

            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var userToInsert = new User { UserName = "alex@usa.net", Email = "alex@usa.net" };
            userManager.Create(userToInsert, "12qw!@QW");
            userStore = new UserStore<User>(context);
            userManager = new UserManager<User>(userStore);
            userToInsert = new User { UserName = "tanya@gmail.com", Email = "tanya@gmail.com" };
            userManager.Create(userToInsert, "Password@123");
        }

        private void SeedPlayers(ApplicationDbContext context)
        {
            Player[] players = new Player[]
            {
                new Player()
                {
                    Name = "Alexis Sanchez",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65m,
                    Team = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona")
                },
                new Player()
                {
                    Name = "Arjen Robben",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65m,
                    Team = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid")
                },
                new Player()
                {
                    Name = "Franck Ribery",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65m,
                    Team = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C.")
                },
                new Player()
                {
                    Name = "Wayne Rooney",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65m,
                    Team = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C.")
                },
                new Player()
                {
                    Name = "Lionel Messi",
                    BirthDate = DateTime.Parse("1982-01-13"),
                    Height = 1.65m,
                    Team = null
                },
                new Player()
                {
                    Name = "Alexis Sanchez",
                    BirthDate = DateTime.Parse("1982-01-03"),
                    Height = 1.65m,
                    Team = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona")
                },
                new Player()
                {
                    Name = "Theo Walcott",
                    BirthDate = DateTime.Parse("1983-02-17"),
                    Height = 1.75m,
                    Team = null
                },
                new Player()
                {
                    Name = "Cristiano Ronaldo",
                    BirthDate = DateTime.Parse("1984-03-16"),
                    Height = 1.85m,
                    Team = null
                },
                new Player()
                {
                    Name = "Aaron Lennon",
                    BirthDate = DateTime.Parse("1985-04-15"),
                    Height = 1.95m,
                    Team = null
                },
                new Player()
                {
                    Name = "Gareth Bale",
                    BirthDate = DateTime.Parse("1986-05-14"),
                    Height = 1.90m,
                    Team = null
                },
                new Player()
                {
                    Name = "Antonio Valencia",
                    BirthDate = DateTime.Parse("1987-05-23"),
                    Height = 1.82m,
                    Team = null
                },
                new Player()
                {
                    Name = "Robin van Persie",
                    BirthDate = DateTime.Parse("1988-06-13"),
                    Height = 1.84m,
                    Team = null
                },
                new Player()
                {
                    Name = "Ronaldinho",
                    BirthDate = DateTime.Parse("1989-07-30"),
                    Height = 1.87m,
                    Team = null
                },
            };

            foreach (var player in players)
            {
                context.Players.Add(player);
            }

            context.SaveChanges();

        }

        private void SeedMatches(ApplicationDbContext context)
        {
            Match[] matches = new Match[]
            {
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-13"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C.")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-14"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Bayern Munich"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C.")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-15"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester City")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-16"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-17"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester City")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-18"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester United F.C."),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-12"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Arsenal"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Bayern Munich")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-11"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Real Madrid")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-10"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Manchester City")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-19"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Chelsea"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "Arsenal")
                },
                new Match()
                {
                    MatchDateTime = DateTime.Parse("2015-Jun-20"),
                    HomeTeam = context.Teams.FirstOrDefault(t => t.Name == "Arsenal"),
                    AwayTeam = context.Teams.FirstOrDefault(t => t.Name == "FC Barcelona")
                }
            };

            foreach (var match in matches)
            {
                context.Matches.Add(match);
            }

            context.SaveChanges();
        }

        private void SeedTeams(ApplicationDbContext context)
        {
            Team[] teams = new Team[]
            {
                new Team()
                {
                    Name = "Manchester United F.C.",
                    Website = "http://www.manutd.com",
                    DateFounded = DateTime.Parse("1-Jun-1878"),
                    NickName = "The Red Devils"
                },
                new Team()
                {
                    Name = "Real Madrid",
                    Website = "http://www.realmadrid.com",
                    DateFounded = DateTime.Parse("6-Mar-1902"),
                    NickName = "The Whites"
                },
                new Team()
                {
                    Name = "FC Barcelona",
                    Website = "http://www.fcbarcelona.com",
                    DateFounded = DateTime.Parse("12-Nov-1899"),
                    NickName = "Barca"
                },
                new Team()
                {
                    Name = "Bayern Munich",
                    Website = "http://www.fcbayern.de",
                    DateFounded = DateTime.Parse("13-Feb-1900"),
                    NickName = "The Bavarians"
                },
                new Team()
                {
                    Name = "Manchester City",
                    Website = "http://www.mcfc.com",
                    DateFounded = DateTime.Parse("1-May-1880"),
                    NickName = "The Citizens"
                },
                new Team()
                {
                    Name = "Chelsea",
                    Website = "http://www.realmadrid.com",
                    DateFounded = DateTime.Parse("6-Mar-1902"),
                    NickName = "The Whites"
                },
                new Team()
                {
                    Name = "Real Madrid",
                    Website = "https://www.chelseafc.com",
                    DateFounded = DateTime.Parse("10-Mar-1905"),
                    NickName = "The Pensioners"
                },
                new Team()
                {
                    Name = "Arsenal",
                    Website = "http://www.arsenal.com",
                    DateFounded = DateTime.Parse("1-Sep-1886"),
                    NickName = "The Gunners"
                },
            };

            foreach (var team in teams)
            {
                context.Teams.Add(team);
            }

            context.SaveChanges();
        }
    }
}
