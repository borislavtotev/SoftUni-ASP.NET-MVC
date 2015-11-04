using System.Data.Entity;
using Bookmarks.App.Model;

namespace Bookmarks.App.Data
{
    public interface IBookmarksDbContext
    {
        DbSet<Bookmark> Bookmarks { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<Vote> Votes { get; set; }

        DbSet<Comment> Comments { get; set; }
    }
}