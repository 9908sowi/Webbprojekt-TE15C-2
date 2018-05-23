using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IGEN.Models;

namespace IGEN.Controllers
{
    public class ArticlesController : Controller
    {
        private ContentDbContext db = new ContentDbContext();

        // GET: Articles
        public ActionResult Index(string search)
        {
            var article = db.Article.Include(a => a.Game);
            if (!String.IsNullOrEmpty(search))
            {
                article = article.Where(a => a.Header.Contains(search));
            }
            ViewBag.SearchText = search;
            return View(article.ToList());
        }

        // GET: Articles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Article article = db.Article.Find(id);

            if (article == null)
            {
                return HttpNotFound();
            }

            if (article.IsLocked)
            {
                /*Make sure only subscriber gain access*/
                if (User.IsInRole("Subscriber") || User.IsInRole("Admin") || User.IsInRole("Creator"))
                {
                    /*Adding visits to the specific article. Since you dont set the visits when creating new article, it becomes null. If never visited, it is null so set first time visiting to 1.*/
                    if (article.Visits == null)
                    {
                        article.Visits = 1;
                        db.SaveChanges();
                    }
                    else
                    {
                        article.Visits = article.Visits + 1;
                        db.SaveChanges();
                    }

                    return View(article);
                }
                else
                {
                    /*Making sure we redirect properly back to where we should with the parameters we send to the controller, after we logged in.*/
                    if(User.IsInRole("Visitor"))
                    {
                        return RedirectToAction("Subscribe", "HomeEdits", new { loggedin = true });
                    }
                    else
                    {
                        return RedirectToAction("Subscribe", "HomeEdits", new { loggedin = false });
                    }
                }
            }
            else
            {
                if (article.Visits == null)
                {
                    article.Visits = 1;
                    db.SaveChanges();
                }
                else
                {
                    article.Visits = article.Visits + 1;
                    db.SaveChanges();
                }

                return View(article);
            }
        }

        [Authorize(Roles = "Creator, Admin")]
        // GET: Articles/Create
        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Game, "ID", "Title");
            return View();
        }

        [Authorize(Roles = "Creator, Admin")]
        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Header,BigPic,Date,Author,Text,GameID,Visits,IsLocked")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Article.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Game, "ID", "Title", article.GameID);
            return View(article);
        }

        [Authorize(Roles = "Creator, Admin")]
        // GET: Articles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Game, "ID", "Title", article.GameID);
            return View(article);
        }

        [Authorize(Roles = "Creator, Admin")]
        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Header,BigPic,Date,Author,Text,GameID,Visits,IsLocked")] Article article)
        {
            if (ModelState.IsValid)
            {
                db.Entry(article).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Game, "ID", "Title", article.GameID);
            return View(article);
        }

        [Authorize(Roles = "Creator, Admin")]
        // GET: Articles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Article article = db.Article.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [Authorize(Roles = "Creator, Admin")]
        // POST: Articles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = db.Article.Find(id);
            db.Article.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index", "HomeEdits");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
