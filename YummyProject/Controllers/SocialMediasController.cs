using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class SocialMediasController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.SocialMedias.ToList();
            return View(values);
        }

        public ActionResult AddSocialMed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSocialMed(SocialMedia socmed)
        {
            if (!ModelState.IsValid)
            {
                return View(socmed);
            }
            context.SocialMedias.Add(socmed);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMed(int id)
        {
            var count = context.SocialMedias.Count();
            if (count > 4)
            {
                var deleted_value = context.SocialMedias.Find(id);
                context.SocialMedias.Remove(deleted_value);
                context.SaveChanges();

            }
            else
            {
                TempData["ErrorMessage"] = "En az 4 sosyal medya hesabı bulunması gerekiyor.";

            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateSocialMed(int id)
        {
            var values = context.SocialMedias.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateSocialMed(SocialMedia scmd)
        {

            var value = context.SocialMedias.Find(scmd.SocialMediaId);
            value.Url = scmd.Url;
            value.Title = scmd.Title;
            value.Icon = scmd.Icon;

            if (!ModelState.IsValid)
            {
                return View(scmd);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}