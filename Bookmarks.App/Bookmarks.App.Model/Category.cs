using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Bookmarks.App.Model
{
    public class Category
    {
        public Category()
        {
            this.Bookmarks = new HashSet<Bookmark>();
        }

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Bookmark> Bookmarks { get; set; }
    }
}