using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class PhotoGalleryController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var photo = context.PhotoGalleries.OrderBy(p => p.PhotoGalleryId).ToList();
            return View(photo);
        }

        public ActionResult AddPhotoGallery()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPhotoGallery(PhotoGallery photogal)
        {
            if (!ModelState.IsValid)
            {
                return View(photogal);
            }
            context.PhotoGalleries.Add(photogal);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeletePhotoGal(int id)
        {
            var value = context.PhotoGalleries.Find(id);
            context.PhotoGalleries.Remove(value);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Fotoğraf silindi.";
            return RedirectToAction("Index");
        }
    }
}