using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Chefs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddChef()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddChef(Chef ch)
        {
            if (!ModelState.IsValid)
            {
                return View(ch);
            }
            context.Chefs.Add(ch);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteChef(int id)
        {
            var value = context.Chefs.Find(id);
            if (value != null)
            {
                context.Chefs.Remove(value);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Şef başarıyla silindi.";
                return RedirectToAction("Index");
            }

            else
            {
                TempData["ErrorMessage"] = "Şef silinemedi.";
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult UpdateChef(int id)
        {
            var value = context.Chefs.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateChef(Chef chf)
        {
            if (!ModelState.IsValid)
            {
                return View(chf);
            }
            var value = context.Chefs.Find(chf.ChefId);
            value.ImageUrl = chf.ImageUrl;
            value.Name = chf.Name;
            value.Title = chf.Title;
            value.Description = chf.Description;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}