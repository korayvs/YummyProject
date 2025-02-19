using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ChefSocialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index(int id = 1)
        {
            var values = context.ChefSocials.Where(x => x.ChefId == id).ToList();
            ViewBag.ChefId = id; //Viewbag ile gönderme
            return View(values);
        }

        [HttpGet]
        public ActionResult AddChefSocial(int id)
        {
            var chef = context.Chefs.Find(id);
            if (chef == null)
            {
                return HttpNotFound();
            }

            var chefSocial = new ChefSocial
            {
                ChefId = chef.ChefId
            };

            return View(chefSocial);
        }

        [HttpPost]
        public ActionResult AddChefSocial(ChefSocial chefSm)
        {
            if (ModelState.IsValid)
            {
                context.ChefSocials.Add(chefSm);
                context.SaveChanges();
                return RedirectToAction("Index", new { id = chefSm.ChefId });
            }

            ViewBag.ChefId = chefSm.ChefId;
            return View(chefSm);
        }

        public ActionResult DeleteChefSocial(int id)
        {
            var chefId = context.ChefSocials.Find(id).ChefId;
            var delvalue = context.ChefSocials.Find(id);
            context.ChefSocials.Remove(delvalue);
            context.SaveChanges();
            return RedirectToAction("Index", new { id = chefId });
        }

        [HttpGet]
        public ActionResult UpdateChefSocial(int id)
        {
            var chefSocial = context.ChefSocials.Find(id);
            if (chefSocial == null)
            {
                return HttpNotFound();
            }
            return View(chefSocial);
        }

        [HttpPost]
        public ActionResult UpdateChefSocial(ChefSocial model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var value = context.ChefSocials.Find(model.ChefSocialId);
            if (value == null)
            {
                return HttpNotFound();
            }

            value.Url = model.Url;
            value.Icon = model.Icon;
            value.SocialMediaName = model.SocialMediaName;            
            context.SaveChanges();
            return RedirectToAction("Index", new { id = model.ChefId });
        }
    }
}