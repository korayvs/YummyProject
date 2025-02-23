using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class ProductController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var values = context.Products.OrderBy(p => p.ProductId).ToList();
            return View(values);
        }

        private void CategoryDropDown()
        {
            var categoryList = context.Categories.ToList();
            List<SelectListItem> categories = (from x in categoryList
                                               select new SelectListItem
                                               {
                                                   Text = x.CategoryName,
                                                   Value = x.CategoryId.ToString(),
                                               }).ToList();

            ViewBag.categories = categories;
        }

        public ActionResult AddProduct()
        {
            CategoryDropDown();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product prdc)
        {
            CategoryDropDown();

            if (!ModelState.IsValid)
            {
                return View(prdc);
            }
            context.Products.Add(prdc);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var values = context.Products.Find(id);
            context.Products.Remove(values);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UpdateProduct(int id)
        {
            CategoryDropDown();
            var values = context.Products.Find(id);
            return View(values);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product pdc)
        {
            CategoryDropDown();

            var value = context.Products.Find(pdc.ProductId);
            value.ImageUrl = pdc.ImageUrl;
            value.ProductName = pdc.ProductName;
            value.Ingredients = pdc.Ingredients;
            value.Price = pdc.Price;
            value.CategoryId = pdc.CategoryId;

            if (!ModelState.IsValid)
            {
                return View(pdc);
            }
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}