namespace Bookmarks.App.ViewModels
{
    using Bookmarks.App.Common.Mappings;
    using Bookmarks.App.Model;

    public class BookmarkViewModel :IMapFrom<Bookmark>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}