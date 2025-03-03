using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        YummyContext context = new YummyContext();

        public ActionResult Index()
        {
            ViewBag.soupCount = context.Products.Count(x => x.Category.CategoryName == "Çorbalar");
            ViewBag.mostExpensive = context.Products.OrderByDescending(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.avgPrice = context.Products.Average(x => x.Price);
            ViewBag.cheapestPrice = context.Products.OrderBy(x => x.Price).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.maincourseCount = context.Products.Count(x => x.Category.CategoryName == "Ana Yemekler");
            ViewBag.snackCount = context.Products.Count(x => x.Category.CategoryName == "Ara Sıcaklar");
            ViewBag.dessertCount = context.Products.Count(x => x.Category.CategoryName == "Tatlılar");
            ViewBag.drinkCount = context.Products.Count(x => x.Category.CategoryName == "İçecekler");
            ViewBag.eventmostExpensive = context.Events.OrderByDescending(x => x.Price).Select(x => x.Title).FirstOrDefault();

            var values = context.Products.OrderByDescending(x => x.ProductId).Take(10).ToList();
            return View(values);
        }
    }
}