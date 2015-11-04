using AutoMapper;
using Bookmarks.App.Common.Mappings;
using Bookmarks.App.Model;

namespace Bookmarks.App.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public class CommentViewModel : IMapFrom<Comment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string User { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Comment, CommentViewModel>()
                .ForMember(x => x.User, cnf => cnf.MapFrom(m => m.User.UserName));
        }
    }
}