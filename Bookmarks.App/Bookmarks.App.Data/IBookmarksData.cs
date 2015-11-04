using Bookmarks.App.Data.Repositories;
using Bookmarks.App.Model;

namespace Bookmarks.App.Data
{
    public interface IBookmarksData
    {
        IRepository<User> Users { get; }

        IRepository<Bookmark> Bookmarks { get; }

        IRepository<Category> Categories { get; }

        IRepository<Vote> Votes { get; }

        IRepository<Comment> Comments { get; }

        void SaveChanges();
    }
}