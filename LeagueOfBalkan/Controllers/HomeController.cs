using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using LeagueOfBalkan.Models;

namespace LeagueOfBalkan.Controllers
{
    public class HomeController : Controller
    {
        private NewsDBContext db = new NewsDBContext();

        public ActionResult Index()
        {
            var query = db.News.OrderByDescending(n => n.Date)
                               .Take(2)
                               .ToList();

            return View(query);
        }
    }
}