using System.ComponentModel.DataAnnotations;

namespace Bookmarks.App.InputModels
{
    using Bookmarks.App.Common.Mappings;
    using Bookmarks.App.Model;

    public class BookmarkInputModel : IMapTo<Bookmark>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        [StringLength(200, ErrorMessage = "The {0} should be between {2} and {1}")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        [StringLength(200, ErrorMessage = "The {0} should be between {2} and {1}")]
        [Url(ErrorMessage = "The url is invalid.")]
        public string Url { get; set; }

        public string Description { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }
    }
}