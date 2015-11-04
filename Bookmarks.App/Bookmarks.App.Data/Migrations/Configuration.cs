using System.Web;
using Bookmarks.App.Model;

namespace Bookmarks.App.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<Bookmarks.App.Data.BookmarksDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "Bookmarks.App.Data.ApplicationDbContext";
        }

        protected override void Seed(Bookmarks.App.Data.BookmarksDbContext context)
        {
//            if (!context.Users.Any())
//            {
//                var user = new ApplicationUser() {UserName = "btotev", Email = "btotev@abv.bg"};
//                var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//
//                var result = userManager.Create(user, "S0m3@Pa$$");
//            }


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
