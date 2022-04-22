using _10TACULT.Data;
using _10TACULT.Models.Dev_Models;
using _10TACULT.Models.Game_Models;
using _10TACULT.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _10TACULT.WebMVC.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GETALL: Game
        public ActionResult Index()
        {
            var service = CreateGameService();
            var model = service.GetAllGames();
            return View(model);
        }

        public ActionResult Create()
        {
            var ctx = new ApplicationDbContext();

            TempData["Devs"] = ctx.Developers
                .Select(g => new SelectListItem()
                {
                    Text = g.DevName,
                    Value = g.DevID.ToString()
                }).ToArray();
            TempData["Pubs"] = ctx.Publishers
                .Select(p => new SelectListItem()
                {
                    Text = p.PublisherName,
                    Value = p.PublisherID.ToString()
                }).ToArray();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateGameService();
                if (service.CreateGame(model))
                {
                    TempData["Save"] = "Game Successfully Added...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Add Game!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
            return View(model);
        }

        // GET: Game/{id}
        public ActionResult Details(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateGameService();
            var model = service.GetGameByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteGame(int id)
        {
            var service = CreateGameService();
            if (service.DeleteGame(id))
            {
                TempData["Save"] = "Game Successfully Removed...";
            }
            else
            {
                TempData["Save"] = "Unable To Delete Game";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGameService();
            var game = service.GetGameByID(id);
            var model = new GameEdit()
            {
                GameID = game.GameID,
                GameTitle = game.GameTitle,
                Genre = game.Genre,
                ReleaseDate = game.ReleaseDate,
                ESRB = game.ESRB,
                Publisher = game.Publisher,
                Developer = game.Developer,
                Platforms = game.Platforms,
                Tags = game.Tags
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GameEdit model)
        {
            var service = CreateGameService();
            if (service.UpdateGame(model))
            {
                TempData["Save"] = "Game Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Game!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public GameService CreateGameService()
        {
            return new GameService(User.Identity.GetUserId());
        }
    }
}