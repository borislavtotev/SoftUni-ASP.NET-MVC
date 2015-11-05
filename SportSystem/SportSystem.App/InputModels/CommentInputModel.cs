using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.InputModels
{
    public class CommentInputModel : IMapTo<Comment>
    {
        public string Content { get; set; }

        public DateTime CreationDateTime { get; set; }

        public string OwnerUserId { get; set; }

        public int MatchId { get; set; }
    }
}