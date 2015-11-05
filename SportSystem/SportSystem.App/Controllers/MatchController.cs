using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNet.Identity;
using PagedList;
using SportSystem.App.Data.UnitOfWork;
using SportSystem.App.InputModels;
using SportSystem.App.Model;
using SportSystem.App.ViewModels;

namespace SportSystem.App.Controllers
{
    public class MatchController : BaseController
    {
        public MatchController(ISportSystemData data) : base(data)
        {
        }

        // GET: Match
        public ActionResult All(int? page)
        {
            var matches = this.Data.Matches
                .All()
                .OrderBy(m => m.HomeTeam.Name + m.AwayTeam.Name)
                .Project()
                .To<MatchViewModel>()
                .ToPagedList(page ?? 1, 3); ;

            return View(matches);
        }

        public ActionResult Details(int id)
        {
            var match = this.Data.Matches
                .All()
                .Where(m => m.Id == id)
                .Project()
                .To<MatchDetailsViewModel>()
                .FirstOrDefault();

            return View(match);
        }

        [HttpPost]
        [Authorize]
        public ActionResult HomeBet(BetInputModel model)
        {
            model.MatchId = Int16.Parse(RouteData.Values["id"].ToString());

            var match = this.Data.Matches.All().FirstOrDefault(m => m.Id == model.MatchId);

            if (match != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                model.UserId = userId;

                var bet = Mapper.Map<Bet>(model);

                this.Data.Bets.Add(bet);

                this.Data.SaveChanges();

                return this.Content(match.Bets.Select(b => b.HomeBet).Sum().ToString());
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Unable to bet for this team and match."); ;
        }

        [HttpPost]
        [Authorize]
        public ActionResult AwayBet(BetInputModel model)
        {
            model.MatchId = Int16.Parse(RouteData.Values["id"].ToString());

            var match = this.Data.Matches.All().FirstOrDefault(m => m.Id == model.MatchId);

            if (match != null && this.ModelState.IsValid)
            {
                var userId = this.User.Identity.GetUserId();
                model.UserId = userId;

                var bet = Mapper.Map<Bet>(model);

                this.Data.Bets.Add(bet);

                this.Data.SaveChanges();

                return this.Content(match.Bets.Select(b => b.AwayBet).Sum().ToString());
            }

            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Unable to bet for this team and match."); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(CommentInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                model.OwnerUserId = this.User.Identity.GetUserId();
                model.CreationDateTime = DateTime.Now;
                model.MatchId = Int16.Parse(RouteData.Values["id"].ToString());
                var comment = Mapper.Map<Comment>(model);
                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var commentDb = this.Data.Comments
                    .All()
                    .Where(c => c.Id == comment.Id)
                    .Project()
                    .To<CommentViewModel>()
                    .FirstOrDefault();

                return this.PartialView("DisplayTemplates/CommentViewModel", commentDb);
            }

            return this.Json("Error");
        }
    }
}