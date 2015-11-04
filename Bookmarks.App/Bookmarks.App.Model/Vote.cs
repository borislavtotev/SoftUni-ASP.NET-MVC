using System.ComponentModel.DataAnnotations;

namespace Bookmarks.App.Model
{
    public class Vote
    {
        [Required]
        [Key]
        public int Id { get; set; }

        public virtual Bookmark Bookmark { get; set; }
        
        [Required]
        public int BookmarkId { get; set; }

        public virtual User User { get; set; }

        [Required]
        public string UserId { get; set; } 
    }
}