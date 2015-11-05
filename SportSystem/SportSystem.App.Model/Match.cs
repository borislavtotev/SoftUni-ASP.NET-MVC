using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSystem.App.Model
{
    public class Match
    {
        private ICollection<Comment> comments; 
        private ICollection<Bet> bets; 

        public Match()
        {
            this.Comments = new HashSet<Comment>();
            this.Bets = new HashSet<Bet>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("HomeTeamId")]
        public virtual Team HomeTeam { get; set; }

        [Required]
        public int HomeTeamId { get; set; }

        [ForeignKey("AwayTeamId")]
        public virtual Team AwayTeam { get; set; }

        [Required]
        public int AwayTeamId { get; set; }

        [Required]
        public DateTime MatchDateTime { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }

        public virtual ICollection<Bet> Bets
        {
            get { return this.bets; }
            set { this.bets = value; }
        }
    }
}