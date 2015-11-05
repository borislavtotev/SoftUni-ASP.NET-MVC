using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string OwnerUserName { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.OwnerUserName, cnf => cnf.MapFrom(m => m.OwnerUser.UserName));
        }
    }
}