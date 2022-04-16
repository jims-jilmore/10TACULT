using _10TACULT.Models.Platform_Models;
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
    public class PlatformController : Controller
    {
        // GETALL: Platform
        public ActionResult Index()
        {
            var service = CreatePlatformService();
            var model = service.GetAllPlatforms();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlatformCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreatePlatformService();
                if (service.CreatePlatform(model))
                {
                    TempData["Save"] = "Platform Successfully Added...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Add Platform!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
            return View(model);
        }

        // GET: Platform/{id}
        public ActionResult Details(int id)
        {
            var service = CreatePlatformService();
            var model = service.GetPlatformByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreatePlatformService();
            var model = service.GetPlatformByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePlatform(int id)
        {
            var service = CreatePlatformService();
            if (service.DeletePlatform(id))
            {
                TempData["Save"] = "Platform Successfully Removed...";
            }
            else
            {
                TempData["Save"] = "Unable To Remove Platform!!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePlatformService();
            var platform = service.GetPlatformByID(id);
            var model = new PlatformEdit()
            {
                PlatformID = platform.PlatformID,
                PlatformName = platform.PlatformName,
                PlatformDeveloper = platform.PlatformDeveloper,
                ReleaseDate = platform.ReleaseDate
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlatformEdit model)
        {
            var service = CreatePlatformService();
            if (service.UpdatePlatform(model))
            {
                TempData["Save"] = "Platform Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Platform!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public PlatformService CreatePlatformService()
        {
            return new PlatformService(User.Identity.GetUserId());
        }
    }
}