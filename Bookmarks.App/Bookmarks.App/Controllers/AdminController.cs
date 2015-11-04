namespace Bookmarks.App.Controllers
{
    using System.Web.Mvc;
    using Bookmarks.App.Data;

    [Authorize(Roles = "Admin")]
    public abstract class AdminController : BaseController
    {
        public AdminController(IBookmarksData data) : base(data)
        {
        }
    }
}