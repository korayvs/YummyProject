using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;

namespace YummyProject.Controllers
{
    public class MessageController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult UnreadMessage()
        {
            var values = context.Messages.Where(x => x.IsRead == false).ToList();
            return View(values);
        }

        public ActionResult ReadMessages()
        {
            var values = context.Messages.Where(x => x.IsRead == true).ToList();
            return View(values);
        }

        public ActionResult MarkAsRead(int id)
        {
            var message = context.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            message.IsRead = true;
            context.SaveChanges();
            TempData["SuccessMessage"] = "Mesaj okundu olarak işaretlendi.";
            return RedirectToAction("UnreadMessage");
        }

        public ActionResult DeleteReadMes(int id)
        {
            var values = context.Messages.Find(id);
            context.Messages.Remove(values);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Mesaj silindi.";
            return RedirectToAction("ReadMessages");
        }
    }
}