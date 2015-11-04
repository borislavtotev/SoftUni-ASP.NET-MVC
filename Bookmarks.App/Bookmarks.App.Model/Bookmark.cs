using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookmarks.App.Model
{
    public class Bookmark
    {
        public Bookmark()
        {
            this.Votes = new HashSet<Vote>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(200)]
        public string Title { get; set; }

        [Required]
        [MinLength(1), MaxLength(200)]
        public string Url { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Vote> Votes { get; set; } 

        public virtual ICollection<Comment> Comments { get; set; } 
    }
}