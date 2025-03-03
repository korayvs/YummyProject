using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class AdminProfileController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Admins.ToList();
            return View(values);
        }

        public ActionResult AddAdminP()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdminP(Admin adminpr)
        {
            if (!ModelState.IsValid)
            {
                return View(adminpr);
            }
            context.Admins.Add(adminpr);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAdminP(int id)
        {
            var delvalue = context.Admins.Find(id);
            context.Admins.Remove(delvalue);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAdminp(int id)
        {
            var values = context.Admins.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateAdminp(Admin admnp)
        {

            var value = context.Admins.Find(admnp.AdminId);
            value.NameSurname = admnp.NameSurname;
            value.UserName = admnp.UserName;
            value.Password = admnp.Password;
            value.ImageUrl = admnp.ImageUrl;

            if (!ModelState.IsValid)
            {
                return View(admnp);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}