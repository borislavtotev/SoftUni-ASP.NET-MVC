using AutoMapper;
using Snippy.App.Model;
using SportSystem.App.Common.Mappings;

namespace Snippy.App.Models.ViewModels
{
    public class LabelViewModel : IMapFrom<Label>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int SnippersCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Label, LabelViewModel>()
                .ForMember(x => x.SnippersCount, cnf => cnf.MapFrom(l => l.Snippets.Count));
        }
    }
}