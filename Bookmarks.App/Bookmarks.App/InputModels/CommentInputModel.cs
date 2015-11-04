using System.ComponentModel.DataAnnotations;
using Bookmarks.App.Common.Mappings;
using Bookmarks.App.Model;

namespace Bookmarks.App.InputModels
{
    public class CommentInputModel : IMapTo<Comment>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        public string Text { get; set; }

        public int BookmarkId { get; set; }

        public string UserId { get; set; }
    }
}