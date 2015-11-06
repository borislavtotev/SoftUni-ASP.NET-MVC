using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Snippy.App.Model;

namespace Snippy.App.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>, IApplicaitonDbContext
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Comment> Comments { get; set; }

        public IDbSet<Label> Labels { get; set; }

        public IDbSet<Language> Languages { get; set; }

        public IDbSet<Snippet> Snippets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Snippet>()
                .HasRequired(snippet => snippet.Author)
                .WithMany(user => user.Snippets)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}
