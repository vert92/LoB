using LeagueOfBalkan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace LeagueOfBalkan.Controllers
{
    public class ForumController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View(db.Discussion.ToList());
        }

        public ActionResult Discussion(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.Thread.Where(t => t.DiscussionID == id)
                                 .OrderByDescending(t => t.DateCreated)
                                 .ToList());
        }

        public ActionResult Thread(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(db.Post.Where(p => p.ThreadID == id)
                               .OrderByDescending(p => p.DateCreated)
                               .ToList());
        }

    }
}