using _10TACULT.Models.Dev_Models;
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
    public class DevController : Controller
    {
        // GETALL: Dev
        public ActionResult Index()
        {
            var service = CreateDevService();
            var model = service.GetAllDevs();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DevCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateDevService();
                if (service.CreateDev(model))
                {
                    TempData["Save"] = "Developer Successfully Added...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Add Developer!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
            return View(model);
        }

        // GET: Dev/{id}    
        public ActionResult Details(int id)
        {
            var service = CreateDevService();
            var model = service.GetDevByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateDevService();
            var model = service.GetDevByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteDev(int id)
        {
            var service = CreateDevService();
            if (service.DeleteDev(id))
            {
                TempData["Save"] = "Developer Successfully Removed...";
            }
            else
            {
                TempData["Save"] = "Unable To Remove Developer!!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDevService();
            var dev = service.GetDevByID(id);
            var model = new DevEdit()
            {
                DevID = dev.DevID,
                DevName = dev.DevName
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DevEdit model)
        {
            var service = CreateDevService();
            if (service.UpdateDev(model))
            {
                TempData["Save"] = "Developer Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Developer!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public DevService CreateDevService()
        {
            return new DevService(User.Identity.GetUserId());
        }
    }
}