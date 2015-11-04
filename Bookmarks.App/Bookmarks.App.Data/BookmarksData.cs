using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Bookmarks.App.Data.Repositories;
using Bookmarks.App.Model;

namespace Bookmarks.App.Data
{
    public class BookmarksData : IBookmarksData
    {
        private BookmarksDbContext context;
        private IDictionary<Type, object> repositories;

        public BookmarksData(BookmarksDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Bookmark> Bookmarks
        {
            get { return this.GetRepository<Bookmark>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Vote> Votes
        {
            get { return this.GetRepository<Vote>(); }
        }

        public IRepository<Category> Categories
        {
            get { return this.GetRepository<Category>(); }
        }

        public BookmarksDbContext Context
        {
            get { return this.context; }
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeof(T),
                    Activator.CreateInstance(type, this.Context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}