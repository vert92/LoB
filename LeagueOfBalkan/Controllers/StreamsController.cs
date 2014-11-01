using LeagueOfBalkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeagueOfBalkan.Helpers;
using LeagueOfBalkan.ViewModels;

namespace LeagueOfBalkan.Controllers
{
    public class StreamsController : Controller
    {
        private LoBDb db = new LoBDb();

        public ActionResult Index()
        {
            return View(db.TwitchData.ToList());
        }

        public ActionResult Details(int? id, string streamName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            StreamPageViewModel twitch = new StreamPageViewModel
            {
                Stream = db.TwitchData.Find(id),
                StreamData = db.TwitchData.OrderByDescending(t => t.viewers)
                          .Take(12)
                          .ToList()
            };

            if (twitch == null)
            {
                return HttpNotFound();
            }

            string expectedName = twitch.Stream.display_name.ToSeoUrl();
            string actualName = (streamName ?? "").ToLower();

            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("Details", new { id = twitch.Stream.ID, streamName = expectedName });
            }

            return View(twitch);
        }
    }
}