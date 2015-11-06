using System;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class CommentShortViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public virtual User Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string Content { get; set; }
    }
}