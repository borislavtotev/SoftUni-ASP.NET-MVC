using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SportSystem.App.Model
{
    public class Team
    {
        private ICollection<Player> players;
        private ICollection<Vote> votes;
        private ICollection<Match> homeMatches;
        private ICollection<Match> awayMatches;

        public Team()
        {
            this.Players = new HashSet<Player>();
            this.Votes = new HashSet<Vote>();
            this.HomeMatches = new HashSet<Match>();
            this.AwayMatches = new HashSet<Match>();
        }    

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string NickName { get; set; }

        public string Website { get; set; }

        public DateTime DateFounded { get; set; }

        public virtual ICollection<Player> Players
        {
            get { return this.players; }
            set { this.players = value; }
        }

        public virtual ICollection<Vote> Votes
        {
            get { return this.votes; }
            set { this.votes = value; }
        }

        public virtual ICollection<Match> HomeMatches
        {
            get { return this.homeMatches; }
            set { this.homeMatches = value; }
        }

        public virtual ICollection<Match> AwayMatches
        {
            get { return this.awayMatches; }
            set { this.awayMatches = value; }
        }
    }
}