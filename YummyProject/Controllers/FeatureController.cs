using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class FeatureController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Features.ToList();
            return View(values);
        }

        //public ActionResult AddFeature()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult AddFeature(Feature feature)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(feature);
        //    }

        //    context.Features.Add(feature);
        //    int result = context.SaveChanges();
        //    if (result == 0)
        //    {
        //        ViewBag.error = "Değerler kaydedilirken bir hata ile karşılaşıldı.";
        //        return View(feature);
        //    }
        //    return RedirectToAction("Index");
        //}

        //public ActionResult DeleteFeature(int id)
        //{
        //    var value = context.Features.Find(id);
        //    context.Features.Remove(value);
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        public ActionResult UpdateFeature(int id)
        {
            var values = context.Features.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateFeature(Feature feature)
        {

            var value = context.Features.Find(feature.FeatureId);
            value.ImageUrl = feature.ImageUrl;
            value.Title = feature.Title;
            value.Description = feature.Description;
            value.VideoUrl = feature.VideoUrl;

            if (!ModelState.IsValid)
            {
                return View(feature);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}