using System;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.InputModels
{
    public class CommentInputModel : IMapTo<Comment>
    {
        public string Content { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string AuthorId { get; set; }

        public int SnippetId { get; set; }
    }
}
    