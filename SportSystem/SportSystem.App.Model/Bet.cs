using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportSystem.App.Model
{
    public class Bet
    {
        [Key]
        public int Id { get; set; }
        
        public virtual Match Match { get; set; }

        [Required]
        public int MatchId { get; set; }

        public decimal? HomeBet { get; set; }

        public decimal? AwayBet { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}