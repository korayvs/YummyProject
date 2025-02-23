using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class TestimonialController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Testimonials.ToList();
            return View(values);
        }

        public ActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddTestimonial(Testimonial tst)
        {
            if (!ModelState.IsValid)
            {
                return View(tst);
            }
            context.Testimonials.Add(tst);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var count = context.Testimonials.Count();
            if (count > 3)
            {
                var deleted_value = context.Testimonials.Find(id);
                context.Testimonials.Remove(deleted_value);
                context.SaveChanges();

            }
            else
            {
                TempData["ErrorMessage"] = "En az 3 referans bulunması gerekiyor.";

            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonials.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial tstm)
        {
            var value = context.Testimonials.Find(tstm.TestimonialId);
            value.ImageUrl = tstm.ImageUrl;
            value.NameSurname = tstm.NameSurname;
            value.Title = tstm.Title;
            value.Comment = tstm.Comment;
            value.Rating = tstm.Rating;

            if (!ModelState.IsValid)
            {
                return View(tstm);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}