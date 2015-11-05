using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using SportSystem.App.Data.UnitOfWork;
using SportSystem.App.InputModels;
using SportSystem.App.Model;
using SportSystem.App.ViewModels;
using WebGrease.Css.Extensions;

namespace SportSystem.App.Controllers
{
    public class TeamController : BaseController
    {
        public TeamController(ISportSystemData data) : base(data)
        {
        }

        [HttpGet]
        [Route("Team/Details/{id:int}")]
        public ActionResult Details(int id)
        {
            var userId = this.User.Identity.GetUserId();
            var vote = this.Data.Votes.All().Where(v => v.TeamId == id && v.UserId == userId).FirstOrDefault();

            if (vote != null)
            {
                ViewBag.HasVoted = true;
            }
            else
            {
                ViewBag.HasVoted = false;
            }

            var team = this.Data.Teams
                .All()
                .Where(t => t.Id == id)
                .Project()
                .To<TeamDetailsViewModel>()
                .FirstOrDefault();

            return View(team);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Vote(int teamId)
        {
            var userId = this.User.Identity.GetUserId();

            var team = this.Data.Teams.All().Where(t => t.Id == teamId).FirstOrDefault();

            if (team != null)
            {
                var vote = team.Votes.FirstOrDefault(v => v.UserId == userId);

                if (vote == null)
                {
                    var newVote = new Vote
                    {
                        TeamId = teamId,
                        UserId = userId
                    };

                    this.Data.Votes.Add(newVote);
                    this.Data.SaveChanges();

                    ViewBag.HasVoted = true;

                    return this.Content(team.Votes.Count().ToString());
                }

            }

            return new EmptyResult();
        }

        [HttpGet]
        public ActionResult Create()
        {
            this.LoadPlayers();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                Player[] players = new Player[model.PlayersIds.Count];
                var team = Mapper.Map<Team>(model);
                this.Data.Teams.Add(team);
                this.Data.SaveChanges();

                foreach (var playersId in model.PlayersIds)
                {
                    var player = this.Data.Players.All().FirstOrDefault(p => p.Id == playersId);
                    player.TeamId = team.Id;
                }

                this.Data.SaveChanges();

                return this.RedirectToAction("Details", new { id = team.Id });
            }

            this.LoadPlayers();

            return this.View(model);
        }

        private void LoadPlayers()
        {
            var players = this.Data
                .Players.All()
                .OrderBy(c => c.Name)
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                });

            ViewBag.Players = players;
        }
    }
}