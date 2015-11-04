using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using Bookmarks.App.Data;
using Bookmarks.App.ViewModels;

namespace Bookmarks.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IBookmarksData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderByDescending(x => x.Votes.Count())
                .Take(6)
                .Project()
                .To<BookmarkViewModel>();

            return View(bookmarks);
        }
    }
}