﻿using System;
using AutoMapper;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class TeamViewModel : IMapFrom<Team>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Website { get; set; }

        public int Votes { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(m => m.Votes.Count));
        }
    }
}