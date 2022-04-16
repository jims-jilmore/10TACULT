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
                    TempData["Save"] = "Clan Successfully Created...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Create Clan!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
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
                TempData["Save"] = "Clan Successfully Removed...";
            }
            else
            {
                TempData["Save"] = "Unable To Remove Clan!!!";
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
                ClanDesc = clan.ClanDesc,
                Members = clan.Members
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
                TempData["Save"] = "Clan Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Clan!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public ClanService CreateClanService()
        {
            return new ClanService(User.Identity.GetUserId());
        }
    }
}