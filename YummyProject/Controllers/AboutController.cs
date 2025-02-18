using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AboutController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            var values = context.Abouts.ToList();
            return View(values);
        }

        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            if (!ModelState.IsValid)
            {
                return View(about);
            }

            context.Abouts.Add(about);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var values = context.Abouts.Find(id);
            context.Abouts.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAbout(int id)
        {
            var values = context.Abouts.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateAbout(About abt)
        {

            var values = context.Abouts.Find(abt.AboutId);
            values.ImageUrl = abt.ImageUrl;
            values.ImageUrl2 = abt.ImageUrl2;
            values.Item1 = abt.Item1;
            values.Item2 = abt.Item2;
            values.Item3 = abt.Item3;
            values.Description = abt.Description;
            values.VideoUrl = abt.VideoUrl;
            values.PhoneNumber = abt.PhoneNumber;

            if (!ModelState.IsValid)
            {
                return View(abt);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}