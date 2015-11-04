using System.Data.Entity;
using Bookmarks.App.Data.Migrations;

namespace Bookmarks.App.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Bookmarks.App.Model;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BookmarksDbContext : IdentityDbContext<User>, IBookmarksDbContext
    {
        public BookmarksDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookmarksDbContext, Configuration>());
        }

        public static BookmarksDbContext Create()
        {
            return new BookmarksDbContext();
        }

        public virtual DbSet<Bookmark> Bookmarks { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Vote> Votes { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }
    }
}
