using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class ServiceController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Services.ToList();
            return View(values);
        }

        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);

        }

        [HttpPost]
        public ActionResult UpdateService(Models.Service srv)
        {

            var value = context.Services.Find(srv.ServiceId);

            value.Title = srv.Title;
            value.Description = srv.Description;
            value.Icon = srv.Icon;

            if (!ModelState.IsValid)
            {
                return View(srv);
            }

            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteService(int id)
        {
            var count = context.Services.Count();
            if (count > 3)
            {
                var deleted_value = context.Services.Find(id);
                context.Services.Remove(deleted_value);
                context.SaveChanges();
            }

            else
            {
                TempData["ErrorMessage"] = "En az 4 hizmetin bulunması gerekiyor.";

            }
            return RedirectToAction("Index");
        }
    }
}