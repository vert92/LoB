using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using LeagueOfBalkan.Models;
using LeagueOfBalkan.ViewModels;

namespace LeagueOfBalkan.Controllers
{
    public class HomeController : Controller
    {
        private LoBDb db = new LoBDb();

        public ActionResult Index()
        {
            var model = new HomePageViewModel
            {
                CarouselNews = db.News.OrderByDescending(n => n.Date)
                                      .Take(3)
                                      .ToList(),

                MainNews = db.News.OrderByDescending(n => n.Date)
                                  .Skip(3)
                                  .Take(3)
                                  .ToList(),

                MiniNews = db.News.OrderByDescending(n => n.Date)
                                  .Skip(6)
                                  .Take(2)
                                  .ToList()
            };

            return View(model);
        }
    }
}