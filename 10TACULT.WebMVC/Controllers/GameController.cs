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
                    return RedirectToAction("Index");
                }
                return View(model);
            }
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
                ////
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
                ESRB = game.ESRB
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
                ////
            }
            return RedirectToAction("Index");
        }

        public GameService CreateGameService()
        {
            return new GameService(User.Identity.GetUserId());
        }
    }
}