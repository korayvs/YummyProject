using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult DefaultFeature()
        {
            var values = context.Features.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultAbout()
        {
            var values = context.Abouts.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultProduct()
        {
            var values = context.Categories.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultBooking()
        {
            var values = context.Bookings.ToList();
            return PartialView(values);
        }

        public ActionResult Booking()
        {
            return View();
        }

        public PartialViewResult DefaultChefs()
        {
            var values = context.Chefs.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultContactInfo()
        {
            var values = context.ContactInfos.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultMessage()
        {
            var values = context.Messages.ToList();
            return PartialView(values);
        }

        [HttpPost]
        public ActionResult SendMessage(Models.Message msg)
        {
            msg.IsRead = false;
            if (ModelState.IsValid)
            {
                context.Messages.Add(msg);
                context.SaveChanges();
                TempData["Message"] = "Mesajınız gönderildi";
                return RedirectToAction("Index", msg);
            }

            return RedirectToAction("Index", msg);
        }

        public PartialViewResult DefaultEvent()
        {
            var values = context.Events.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultPhotoGallery()
        {
            var values = context.PhotoGalleries.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultService()
        {
            var values = context.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultTestimonial()
        {
            var values = context.Testimonials.ToList();
            return PartialView(values);
        }

        public PartialViewResult DefaultStats()
        {
            return PartialView();
        }
    }
}