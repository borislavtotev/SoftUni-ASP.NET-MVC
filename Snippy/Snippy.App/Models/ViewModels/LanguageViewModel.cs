using System.Collections.Generic;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class LanguageViewModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}