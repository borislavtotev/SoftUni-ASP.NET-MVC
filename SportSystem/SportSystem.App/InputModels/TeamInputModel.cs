using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SportSystem.App.Common.Mappings;
using SportSystem.App.Model;

namespace SportSystem.App.InputModels
{
    public class TeamInputModel : IMapTo<Team>
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "The {0} is required.")]
        public string Name { get; set; }

        public string NickName { get; set; }

        [Url(ErrorMessage = "The url is invalid.")]
        public string Website { get; set; }

        public DateTime DateFounded { get; set; }

        public virtual ICollection<int> PlayersIds { get; set; }
    }
}