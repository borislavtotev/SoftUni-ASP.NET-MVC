using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class MatchDetailsViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public int HomeTeamId { get; set; }

        public string AwayTeam { get; set; }

        public int AwayTeamId { get; set; }

        public decimal? HomeTeamBets { get; set; }

        public decimal? AwayTeamBets { get; set; }

        public DateTime MatchDateTime { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchDetailsViewModel>()
                .ForMember(x => x.HomeTeam, cnf => cnf.MapFrom(m => m.HomeTeam.Name.ToString()))
                .ForMember(x => x.AwayTeam, cnf => cnf.MapFrom(m => m.AwayTeam.Name.ToString()))
                .ForMember(x => x.HomeTeamBets, cnf => cnf.MapFrom(m => m.Bets.Select(b => b.HomeBet).Sum()))
                .ForMember(x => x.AwayTeamBets, cnf => cnf.MapFrom(m => m.Bets.Select(b => b.AwayBet).Sum()));
        }
    }
}