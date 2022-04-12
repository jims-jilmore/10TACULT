using _10TACULT.Models.Clan_Models;
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
    public class ClanController : Controller
    {
        // GETALL: Clan
        public ActionResult Index()
        {
            var service = CreateClanService();
            var model = service.GetAllClans();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClanCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateClanService();
                if (service.CreateClan(model))
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            return View(model);
        }

        // GET: Clan/{id}
        public ActionResult Details(int id)
        {
            var service = CreateClanService();
            var model = service.GetClanByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateClanService();
            var model = service.GetClanByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteClan(int id)
        {
            var service = CreateClanService();
            if (service.DeleteClan(id))
            {
                ////
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateClanService();
            var clan = service.GetClanByID(id);
            var model = new ClanEdit()
            {
                ClanID = clan.ClanID,
                ClanName = clan.ClanName,
                ClanDesc = clan.ClanDesc
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClanEdit model)
        {
            var service = CreateClanService();
            if (service.UpdateClan(model))
            {
                ////
            }
            return RedirectToAction("Index");
        }

        public ClanService CreateClanService()
        {
            return new ClanService(User.Identity.GetUserId());
        }
    }
}