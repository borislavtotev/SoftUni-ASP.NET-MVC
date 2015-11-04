using AutoMapper;
using AutoMapper.QueryableExtensions;
using Bookmarks.App.Areas.Admin.ViewModels;
using Bookmarks.App.Model;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace Bookmarks.App.Areas.Admin.Controllers
{
    using System.Web.Mvc;
    using Bookmarks.App.Controllers;
    using Bookmarks.App.Data;

    public class CategoriesController : AdminController
    {
        public CategoriesController(IBookmarksData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            var data = this.Data.Categories
                .All()
                .Project()
                .To<CategoryAdminViewModel>();
            return this.Json(data.ToDataSourceResult(request));
        }

        [HttpPost]
        public ActionResult Create([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = Mapper.Map<Category>(model);
                this.Data.Categories.Add(category);
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Update([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var category = this.Data.Categories.Find(model.Id);
                category.Name = model.Name;
                this.Data.SaveChanges();
            }

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }

        [HttpPost]
        public ActionResult Delete([DataSourceRequest] DataSourceRequest request, CategoryAdminViewModel model)
        {
            this.Data.Categories.Remove(model.Id);
            this.Data.SaveChanges();

            return this.Json(new[] { model }.ToDataSourceResult(request, this.ModelState));
        }
    }
}