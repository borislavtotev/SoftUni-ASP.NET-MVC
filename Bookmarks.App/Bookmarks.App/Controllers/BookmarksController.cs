using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookmarks.App.Data;
using Bookmarks.App.InputModels;
using Bookmarks.App.Model;
using Bookmarks.App.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;

namespace Bookmarks.App.Controllers
{

    [Authorize]
    public class BookmarksController : BaseController
    {
        public BookmarksController(IBookmarksData data) : base(data)
        {
        }

        [AllowAnonymous]
        public ActionResult Index(int? page)
        {
            var bookmarks = this.Data.Bookmarks
                .All()
                .OrderBy(x => x.Title)
                .Project()
                .To<BookmarkViewModel>()
                .ToPagedList(page ?? 1, 6);

            return this.View(bookmarks);
        }

        public ActionResult Details(int id)
        {

            var bookmark = this.Data.Bookmarks
                .All()
                .Where(b => b.Id == id)
                .Project()
                .To<BookmarkDetailsViewModel>()
                .FirstOrDefault();

            return View(bookmark);
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadCategories();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookmarkInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var bookmark = Mapper.Map<Bookmark>(model);
                this.Data.Bookmarks.Add(bookmark);
                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = bookmark.Id });
            }

            this.LoadCategories();

            return this.View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.UserId = this.User.Identity.GetUserId();
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = this.Data.Comments
                    .All()
                    .Where(c => c.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentDb);
            }

            return this.Json("Error");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteComment(int commentId)
        {
            var comment = this.Data.Comments.All().Where(c => c.Id == commentId).FirstOrDefault();

            if (comment != null && comment.UserId == this.User.Identity.GetUserId())
            {
                this.Data.Comments.Remove(comment);
                this.Data.SaveChanges();

                return this.Content(string.Empty);
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Can not delete the comment.");
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int bookmarkId)
        {
            var bookmark = this.Data.Bookmarks.All().Where(b => b.Id == bookmarkId).FirstOrDefault();

            if (bookmark != null)
            {
                var vote = new Vote()
                {
                    BookmarkId = bookmarkId,
                    UserId = this.User.Identity.GetUserId()
                };

                this.Data.Votes.Add(vote);
                this.Data.SaveChanges();

                return this.Content(bookmark.Votes.Count.ToString());
            }

            return new EmptyResult();
        }

        private void LoadCategories()
        {
            var categories = this.Data
                .Categories.All()
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            ViewBag.Categories = categories;
        }
    }
}