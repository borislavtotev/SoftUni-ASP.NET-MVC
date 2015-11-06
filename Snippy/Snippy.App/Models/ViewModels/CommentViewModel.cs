using System;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class CommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public virtual User Author { get; set; }

        public string AuthorId { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string Content { get; set; }

        public virtual Snippet Snippet { get; set; }

        public int SnippetId { get; set; }
    }
}