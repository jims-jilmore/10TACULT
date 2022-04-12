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
                    return RedirectToAction("Index");
                }
                return View(model);
            }
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
                ////
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
                ////
            }
            return RedirectToAction("Index");
        }

        public SessionService CreateSessionService()
        {
            return new SessionService(User.Identity.GetUserId());
        }

    }
}