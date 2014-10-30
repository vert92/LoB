using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LeagueOfBalkan.Models;
using System.IO;
using System.Web.Helpers;
using LeagueOfBalkan.Helpers;
using LeagueOfBalkan.ViewModels;

namespace LeagueOfBalkan.Controllers
{
    public class NewsController : Controller
    {
        private LoBDb db = new LoBDb();

        // GET: News
        public ActionResult Index()
        {

            TwitchData twitch = new TwitchData();


            return View(db.News.ToList());
        }

        // GET: News/Details/5
        [Authorize]
        public ActionResult Details(int? id, string newsName)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //News news = db.News.Find(id);

            var model = new NewsDetailsViewModel
            {
                NewsDetail = db.News.Find(id),
                RecentNews = db.News.OrderByDescending(n => n.Date)
                            .Take(10)
                            .ToList()
            };

            if (model == null)
            {
                return HttpNotFound();
            }

            string expectedName = model.NewsDetail.Title.ToSeoUrl();
            string actualName = (newsName ?? "").ToLower();

            if (expectedName != actualName)
            {
                return RedirectToActionPermanent("Details", new { id = model.NewsDetail.ID, newsName = expectedName });
            }

            return View(model);
        }

        // GET: News/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: News/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Create([Bind(Include = "ID,Title,Text,Image,ImagePath")] News news, string imageEdit)
        {
            if (ModelState.IsValid)
            {
                var newsItem = new News
                {
                    Title = news.Title,
                    Text = news.Text
                };

                if (news.Image != null && news.Image.ContentLength > 0)
                {
                    CreateImage(news, imageEdit);
                }

                db.News.Add(news);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(news);
        }


        // GET: News/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "ID,Title,Text,Image,ImagePath,Date")] News news, string imageEdit)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(news).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");

                News newsEdit = new News (news.Date) { ID = news.ID };
                db.News.Attach(newsEdit);

                newsEdit.Title = news.Title;
                newsEdit.Text = news.Text;
                if (news.Image != null && news.Image.ContentLength > 0)
                {
                    CreateImage(news, imageEdit);
                }
                newsEdit.Image = news.Image;
                newsEdit.ImagePath = news.ImagePath;
                newsEdit.ThumbPath = news.ThumbPath;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(news);
        }

        // GET: News/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            News news = db.News.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);
        }

        // POST: News/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            News news = db.News.Find(id);
            db.News.Remove(news);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

     
        [NonAction]
        public void CreateImage(News news, string imageEdit)
        {
            WebImage img = new WebImage(news.Image.InputStream);
            if (imageEdit == "Resize")
            {
                img.Resize(764, 388, false);
            }
            else if (imageEdit == "Crop")
            {
                if (img.Width > 800 && img.Height > 400)
                {
                    img.Crop((img.Height - 388) / 2, (img.Width - 764) / 2, (img.Height - 388) / 2, (img.Width - 764) / 2);
                }
                else
                {
                    img.Resize(764, 388, false);
                }
            }

            var titleTrimmed = news.Title;
            if (titleTrimmed.Length > 10)
            {
                titleTrimmed = titleTrimmed.Substring(0, 10).Trim();
            }

            var image = titleTrimmed + "_" + DateTime.Now.Date.ToString("ddMyy") + "_" + news.Image.FileName;
            var uploadDir = "~/uploads";
            var imagePath = Path.Combine(Server.MapPath(uploadDir), image);
            var imageUrl = Path.Combine(uploadDir, image);
            img.Save(imagePath);
            news.ImagePath = imageUrl;

            WebImage thumb = new WebImage(imageUrl);
            if (imageEdit == "Resize")
            {
                thumb.Resize(350, 185, false);
            }
            else if (imageEdit == "Crop")
            {
                if (thumb.Width > 800 && img.Height > 400)
                {
                    thumb = img;
                    thumb.Resize(350, 185, false);
                }
                else
                {
                    thumb.Resize(350, 185, false);
                }
            }

            var thumbnail = "thumb" + "_" + titleTrimmed + "_" + DateTime.Now.Date.ToString("ddMyy") + "_" + news.Image.FileName;
            var thumbPath = Path.Combine(Server.MapPath(uploadDir), thumbnail);
            var thumbUrl = Path.Combine(uploadDir, thumbnail);
            thumb.Save(thumbPath);
            news.ThumbPath = thumbUrl;
        }
    }
}
