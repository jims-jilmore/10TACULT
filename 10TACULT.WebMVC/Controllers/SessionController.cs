using _10TACULT.Models.Session_Models;
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
    public class SessionController : Controller
    {
        // GETALL: Session
        public ActionResult Index()
        {
            var service = CreateSessionService();
            var model = service.GetAllSessions();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = CreateSessionService();
                if (service.CreateSession(model))
                {
                    TempData["Save"] = "Session Successfully Created...";
                    return RedirectToAction("Index");
                }
                TempData["Save"] = "Unable To Create Session!!!";
                return View(model);
            }
            TempData["Save"] = "Invalid Model State";
            return View(model);
        }

        // GET: Session/{id}
        public ActionResult Details(int id)
        {
            var service = CreateSessionService();
            var model = service.GetSessionByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateSessionService();
            var model = service.GetSessionByID(id);
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSession(int id)
        {
            var service = CreateSessionService();
            if (service.DeleteSession(id))
            {
                TempData["Save"] = "Session Successfully Removed...";
            }
            else
            {
                TempData["Save"] = "Unable To Remove Session!!!";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSessionService();
            var session = service.GetSessionByID(id);
            var model = new SessionEdit()
            {
                SessionID = session.SessionID,
                SessionTitle = session.SessionTitle,
                SessionDesc = session.SessionDesc,
                SessionDate = session.SessionDate
            };
            if (model is null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            var service = CreateSessionService();
            if (service.UpdateSession(model))
            {
                TempData["Save"] = "Session Successfully Updated...";
            }
            else
            {
                TempData["Save"] = "Unable To Update Session!!!";
            }
            TempData["Save"] = "Invalid Model State";
            return RedirectToAction("Index");
        }

        public SessionService CreateSessionService()
        {
            return new SessionService(User.Identity.GetUserId());
        }

    }
}