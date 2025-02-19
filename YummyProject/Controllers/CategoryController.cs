using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;
using System.Data.Entity;

namespace YummyProject.Controllers
{
    public class CategoryController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Categories.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category ctgr)
        {
            if (!ModelState.IsValid)
            {
                return View(ctgr);
            }
            context.Categories.Add(ctgr);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var category = context.Categories.Include(c => c.Products).FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                TempData["ErrorMessage"] = "Kategori bulunamadı.";
                return RedirectToAction("Index");
            }

            if (category.Products != null && category.Products.Any())
            {
                TempData["ErrorMessage"] = "Bu kategori ile ilişkili ürünler mevcut. Önce bu ürünleri silin.";
                return RedirectToAction("Index");
            }

            context.Categories.Remove(category);
            context.SaveChanges();

            TempData["SuccessMessage"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category model)
        {
            var value = context.Categories.Find(model.CategoryId);
            value.CategoryName = model.CategoryName;

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}