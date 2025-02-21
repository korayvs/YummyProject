using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ContactController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.ContactInfos.ToList();
            return View(values);
        }

        public ActionResult UpdateContact(int id)
        {
            var value = context.ContactInfos.Find(id);
            if (value == null)
            {
                return HttpNotFound();
            }
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateContact(ContactInfo contact)
        {
            var value = context.ContactInfos.Find(contact.ContactInfoId);
            value.Address = contact.Address;
            value.Email = contact.Email;
            value.PhoneNumber = contact.PhoneNumber;
            value.MapUrl = contact.MapUrl;
            value.OpenHours = contact.OpenHours;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}