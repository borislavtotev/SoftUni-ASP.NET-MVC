using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookmarks.App.Common.Mappings;
using Bookmarks.App.Model;

namespace Bookmarks.App.ViewModels
{
    public class BookmarkDetailsViewModel : IMapFrom<Bookmark>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }

        public User User { get; set; }

        public int Votes { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Bookmark, BookmarkDetailsViewModel>()
                .ForMember(x => x.Votes, cnf => cnf.MapFrom(m => m.Votes.Count()));
        }
    }
}