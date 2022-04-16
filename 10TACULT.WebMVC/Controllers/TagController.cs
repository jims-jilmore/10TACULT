using _10TACULT.Models.Tag_Models;
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
    public class TagController : Controller
    {
        // GETALL: Tag
        public ActionResult Index()
        {
            var service = CreateTagService();
            var model = service.GetAllTags();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TagCreate model, int gameID)
        {
            if (ModelState.IsValid)
            {
                var service = CreateTagService();
                if (service.CreateTag(model, gameID))
                {
                    TempData["Save"] = "Tag Successfully Created...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Create Tag!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
            return View(model);
        }

        // GET: Tag/{id}
        public ActionResult Details(int id)
        {
            var service = CreateTagService();
            var model = service.GetTagByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateTagService();
            var model = service.GetTagByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTag(int id)
        {
            var service = CreateTagService();
            if (service.DeleteTag(id))
            {
                TempData["Save"] = "Tag Successfully Removed";
            }
            else
            {
                TempData["Save"] = "Unable To Remove Tag!!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTagService();
            var tag = service.GetTagByID(id);
            var model = new TagEdit()
            {
                TagID = tag.TagID,
                TagName = tag.TagName
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, TagEdit model)
        {
            var service = CreateTagService();
            if (service.UpdateTag(model))
            {
                TempData["Save"] = "Tag Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Tag!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public TagService CreateTagService()
        {
            return new TagService(User.Identity.GetUserId());
        }


    }
}