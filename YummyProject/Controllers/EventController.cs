﻿using System;
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

        public ActionResult DeleteEvent(int id)
        {
            var count = context.Events.Count();
            if (count > 4)
            {
                var deleted_value = context.Events.Find(id);
                context.Events.Remove(deleted_value);
                context.SaveChanges();

            }
            else
            {
                TempData["ErrorMessage"] = "En az 4 etkinliğin bulunması gerekiyor.";

            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateEvent(int id)
        {
            var values = context.Events.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateEvent(Event evnt)
        {

            var value = context.Events.Find(evnt.EventId);
            value.ImageUrl = evnt.ImageUrl;
            value.Title = evnt.Title;
            value.Description = evnt.Description;
            value.Price = evnt.Price;

            if (!ModelState.IsValid)
            {
                return View(evnt);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}