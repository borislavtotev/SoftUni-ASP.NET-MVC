using System;
using System.Collections.Generic;
using AutoMapper;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class TeamDetailsViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string NickName { get; set; }

        public string Website { get; set; }

        public DateTime DateFounded { get; set; }

        public int Votes { get; set; }

        public ICollection<PlayerViewModel> Players { get; set; } 

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamDetailsViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(m => m.Votes.Count));
        }
    }
}