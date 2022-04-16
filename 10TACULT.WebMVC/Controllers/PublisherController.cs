using _10TACULT.Models.Publisher_Models;
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
    public class PublisherController : Controller
    {
        // GETALL: Publisher
        public ActionResult Index()
        {
            var service = CreatePublisherService();
            var model = service.GetAllPublishers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreatePublisherService();
                if (service.CreatePublisher(model))
                {
                    TempData["Save"] = "Publisher Successfully Added...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Add Publisher!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
            return View(model);
        }

        // GET: Publisher/{id}
        public ActionResult Details(int id)
        {
            var service = CreatePublisherService();
            var model = service.GetPublisherByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreatePublisherService();
            var model = service.GetPublisherByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePublisher(int id)
        {
            var service = CreatePublisherService();
            if (service.DeletePublisher(id))
            {
                TempData["Save"] = "Publisher Successfully Removed...";
            }
            else
            {
                TempData["Save"] = "Unable To Remove Publisher";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePublisherService();
            var publisher = service.GetPublisherByID(id);
            var model = new PublisherEdit()
            {
                PublisherID = publisher.PublisherID,
                PublisherName = publisher.PublisherName
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherEdit model)
        {
            var service = CreatePublisherService();
            if (service.UpdatePublisher(model))
            {
                TempData["Save"] = "Publisher Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Publisher!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public PublisherService CreatePublisherService()
        {
            return new PublisherService(User.Identity.GetUserId());
        }


    }
}