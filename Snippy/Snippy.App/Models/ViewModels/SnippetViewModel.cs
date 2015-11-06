using System.Collections.Generic;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class SnippetViewModel : IMapFrom<Snippet>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual IEnumerable<LabelButtonViewModel> Labels { get; set; }
    }
}