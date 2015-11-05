using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SportSystem.App.Model;

namespace SportSystem.App.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<TeamViewModel> BestTeams { get; set; }

        public IEnumerable<MatchViewModel> TopMatches { get; set; }
    }
}