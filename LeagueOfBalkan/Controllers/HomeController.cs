using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using LeagueOfBalkan.Models;
using LeagueOfBalkan.ViewModels;
using System.Net;
using Newtonsoft.Json;

namespace LeagueOfBalkan.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
                                  .ToList(),

                StreamData = db.TwitchData.OrderByDescending(t => t.viewers)
                             .Take(12)
                             .ToList()
            };

            return View(model);
        }
    }
}