using System;
using System.ComponentModel.DataAnnotations;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.InputModels
{
    public class BetInputModel 
    {
        [Range(0,Int32.MaxValue, ErrorMessage = "The bet should be positive number!")]
        public decimal? HomeBet { get; set; }

        [Range(0, Int32.MaxValue, ErrorMessage = "The bet should be positive number!")]
        public decimal? AwayBet { get; set; }

        public string UserId { get; set; }

        public int MatchId { get; set; }
    }
}