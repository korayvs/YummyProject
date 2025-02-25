using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YummyProject.Context;
using YummyProject.Models;

namespace YummyProject.Controllers
{
    public class BookingController : Controller
    {
        YummyContext context = new YummyContext();
        public ActionResult Index()
        {
            var bookings = context.Bookings.ToList();
            return View(bookings);
        }

        [HttpPost]
        public ActionResult Add(Booking booking, string date, string time)
        {
            try
            {
                DateTime parsedDate = DateTime.Parse(date);
                TimeSpan parsedTime = TimeSpan.Parse(time);
                booking.BookingDate = parsedDate.Date + parsedTime;

                using (var cntxt = new YummyContext())
                {
                    cntxt.Bookings.Add(booking);
                    cntxt.SaveChanges();
                }
                return RedirectToAction("Index", "Default");
            }

            catch (Exception ex)
            {
                ModelState.AddModelError("", "Bir hata oluştu: " + ex.Message);
                return View(booking);
            }
        }

        public PartialViewResult FormBooking()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult ApproveRes(int[] approvedBkngs)
        {
            try
            {
                using (var cntxt = new YummyContext())
                {
                    var allBookings = cntxt.Bookings.ToList();

                    foreach (var booking in allBookings)
                    {
                        if (approvedBkngs != null && approvedBkngs.Contains(booking.BookingId))
                        {
                            booking.IsApproved = true;
                        }

                        else
                        {
                            booking.IsApproved = false;
                        }
                    }

                    cntxt.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Bir hata oluştu: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult ShowApproved()
        {
            var bookings = context.Bookings.Where(x => x.IsApproved == true).ToList();
            return View(bookings);
        }

        public ActionResult ShowUnApproved()
        {
            var bookings = context.Bookings.Where(x => x.IsApproved == false).ToList();
            return View(bookings);
        }

        public ActionResult DeleteBooking(int id)
        {
            var value = context.Bookings.Find(id);
            context.Bookings.Remove(value);
            context.SaveChanges();
            TempData["SuccessMessage"] = "Rezervasyon silindi.";
            return RedirectToAction("Index");
        }
    }
}