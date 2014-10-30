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
        private LoBDb db = new LoBDb();

        public ActionResult Index()
        {
            dynamic results;
            var urlx = "https://api.twitch.tv/kraken/streams?game=League+of+Legends";
            using (var w = new WebClient())
            {
                var json_data = string.Empty;

                try
                {
                    json_data = w.DownloadString(urlx);
                }
                catch (Exception) { }

                results = JsonConvert.DeserializeObject(json_data);
            }

            var viewers = new List<int>();
            var medium = new List<string>();
            var display_name = new List<string>();
            var status = new List<string>();
            var url = new List<string>();

            foreach (dynamic item in results.streams)
            {
                viewers.Add((int)item.viewers);
                medium.Add((string)item.preview.medium);
                display_name.Add((string)item.channel.display_name);
                status.Add((string)item.channel.status);
                url.Add((string)item.channel.url);
            }

            var i = 0;

            foreach (dynamic item in results.streams)
            {
                var twitch = new TwitchData
                {
                    viewers = viewers[i],
                    medium = medium[i],
                    display_name = display_name[i],
                    status = status[i],
                    url = url[i]
                };

                db.TwitchData.Add(twitch);
                db.SaveChanges();

                i++;
            }

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

                //StreamData = twitch
            };

            return View(model);
        }
    }
}