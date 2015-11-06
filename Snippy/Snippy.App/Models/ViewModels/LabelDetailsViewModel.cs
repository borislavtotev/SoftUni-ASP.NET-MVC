using System.Collections.Generic;
using AutoMapper;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class LabelDetailsViewModel : IMapFrom<Label>
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public IEnumerable<SnippetViewModel> Snippets { get; set; }
    }
}