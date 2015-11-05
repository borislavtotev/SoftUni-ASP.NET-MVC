using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper.QueryableExtensions;
using SportSystem.App.Data.UnitOfWork;
using SportSystem.App.ViewModels;

namespace SportSystem.App.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ISportSystemData data) : base(data)
        {
        }

        public ActionResult Index()
        {
            var matches = this.Data.Matches
                .All()
                .OrderByDescending(m => m.Bets.Count())
                .Take(3)
                .Project()
                .To<MatchViewModel>();

            var teams = this.Data.Teams
                .All()
                .OrderByDescending(m => m.Votes.Count())
                .Take(3)
                .Project()
                .To<TeamViewModel>();

            var results = new HomeViewModel()
            {
                BestTeams = teams,
                TopMatches = matches
            };

            return View(results);
        }
    }
}