using System;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class PlayerViewModel : IMapFrom<Player>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public Decimal Height { get; set; }
    }
}