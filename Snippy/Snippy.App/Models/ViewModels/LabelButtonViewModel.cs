using AutoMapper;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class LabelButtonViewModel : IMapFrom<Label>
    {
        public int Id { get; set; }

        public string Text { get; set; }
    }
}