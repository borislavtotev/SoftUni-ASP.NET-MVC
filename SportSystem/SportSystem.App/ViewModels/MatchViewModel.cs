using System;
using AutoMapper;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class MatchViewModel : IMapFrom<Match>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public DateTime MatchDateTime { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Match, MatchViewModel>()
                .ForMember(x => x.HomeTeam, cnf => cnf.MapFrom(m => m.HomeTeam.Name.ToString()))
                .ForMember(x => x.AwayTeam, cnf => cnf.MapFrom(m => m.AwayTeam.Name.ToString()));
        }
    }
}