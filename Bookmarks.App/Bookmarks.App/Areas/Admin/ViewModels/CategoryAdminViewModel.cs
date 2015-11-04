using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Bookmarks.App.Common.Mappings;
using Bookmarks.App.Model;

namespace Bookmarks.App.Areas.Admin.ViewModels
{
    public class CategoryAdminViewModel : IMapFrom<Category>, IMapTo<Category>
    {
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(100)]
        public string Name { get; set; }
    }
}