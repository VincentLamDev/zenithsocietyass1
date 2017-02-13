using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZenithDataLib.Models;
using ZenithWebSite.Models;
using System.Data.Entity;
using System.Diagnostics;
using ZenithWebSite.Compare;

namespace ZenithWebSite.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //db access

        public ActionResult Index()
        {

            DateTime today = DateTime.Today;
            DateTime startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            startOfWeek = startOfWeek.AddDays(1.0);
            DateTime endOfWeek = startOfWeek.AddDays(7);

            var activities = db.Activities.Include(a => a.Events)
                                .Where(a => a.Events.All(b => b.Start >= startOfWeek && b.End <= endOfWeek && b.IsActive == true))
                                .Select(a => a);
            return View(activities.ToList());

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}