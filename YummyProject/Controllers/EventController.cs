using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class EventController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Events.ToList();
            return View(values);
        }

        public ActionResult CreateEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateEvent(Event evnt)
        {
            if (!ModelState.IsValid)
            {
                return View(evnt);
            }
            context.Events.Add(evnt);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}