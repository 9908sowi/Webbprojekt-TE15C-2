using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using IGEN.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IGEN.Controllers
{
    public class HomeEditsController : Controller
    {
        private ContentDbContext db = new ContentDbContext();

        // GET: HomeEdits
        public ActionResult Index()
        {
            bool gameExists = db.Game.Any(game => game.ID == game.ID);
            bool articleExists = db.Article.Any(article => article.ID == article.ID);
            bool homeExists = db.HomeEdit.Any(home => home.ID == home.ID);

            /*The following creates a sample article first time starting the project, otherwise it will give an error since much of the content on the startpage depends on there actually existing articles (should be atleast 8 for most read part to show properly)*/
            if (!gameExists)
            {
                Game newgame = new Game();
                newgame.ID = 1;
                newgame.Title = "Sample";
                newgame.CoverArt = "http://www.mobygames.com/images/covers/l/367150-battlefield-1-windows-front-cover.png";
                newgame.Developer = "Sample";
                db.Game.Add(newgame);
                db.SaveChanges();
            }
            if (!articleExists)
            {
                Article newarticle = new Article();
                newarticle.ID = 1;
                newarticle.Header = "Sample";
                newarticle.BigPic = "https://cdn.mos.cms.futurecdn.net/eZ6pqBFQtymNTiksWQCJWo-650-80.jpg";
                newarticle.Date = DateTime.Now;
                newarticle.Author = "Sample";
                newarticle.Text = "Lorem ipsum.";
                newarticle.GameID = 1;
                newarticle.IsLocked = false;
                db.Article.Add(newarticle);
                db.SaveChanges();
            }
            if (!homeExists)
            {
                HomeEdit newhome = new HomeEdit();
                newhome.ID = 1;
                newhome.FrontPicID = 1;
                newhome.CardPic1ID = 1;
                newhome.CardPic2ID = 1;
                newhome.CardPic3ID = 1;
                newhome.CardPic4ID = 1;
                newhome.CardPic5ID = 1;
                newhome.CardPic6ID = 1;
                db.HomeEdit.Add(newhome);
                db.SaveChanges();
            }
            var homeEdit = db.HomeEdit.Include(h => h.CardPic1).Include(h => h.CardPic2).Include(h => h.CardPic3).Include(h => h.CardPic4).Include(h => h.CardPic5).Include(h => h.CardPic6).Include(h => h.FrontPic);
            return View(homeEdit.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: HomeEdits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeEdit homeEdit = db.HomeEdit.Find(id);
            if (homeEdit == null)
            {
                return HttpNotFound();
            }
            return View(homeEdit);
        }

        [Authorize(Roles = "Admin")]
        // GET: HomeEdits/Create
        public ActionResult Create()
        {
            ViewBag.CardPic1ID = new SelectList(db.Article, "ID", "Header");
            ViewBag.CardPic2ID = new SelectList(db.Article, "ID", "Header");
            ViewBag.CardPic3ID = new SelectList(db.Article, "ID", "Header");
            ViewBag.CardPic4ID = new SelectList(db.Article, "ID", "Header");
            ViewBag.CardPic5ID = new SelectList(db.Article, "ID", "Header");
            ViewBag.CardPic6ID = new SelectList(db.Article, "ID", "Header");
            ViewBag.FrontPicID = new SelectList(db.Article, "ID", "Header");
            return View();
        }

        [Authorize(Roles = "Admin")]
        // POST: HomeEdits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FrontPicID,CardPic1ID,CardPic2ID,CardPic3ID,CardPic4ID,CardPic5ID,CardPic6ID")] HomeEdit homeEdit)
        {
            if (ModelState.IsValid)
            {
                db.HomeEdit.Add(homeEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CardPic1ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic1ID);
            ViewBag.CardPic2ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic2ID);
            ViewBag.CardPic3ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic3ID);
            ViewBag.CardPic4ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic4ID);
            ViewBag.CardPic5ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic5ID);
            ViewBag.CardPic6ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic6ID);
            ViewBag.FrontPicID = new SelectList(db.Article, "ID", "Header", homeEdit.FrontPicID);
            return View(homeEdit);
        }

        [Authorize(Roles = "Admin")]
        // GET: HomeEdits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeEdit homeEdit = db.HomeEdit.Find(id);
            if (homeEdit == null)
            {
                return HttpNotFound();
            }
            ViewBag.CardPic1ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic1ID);
            ViewBag.CardPic2ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic2ID);
            ViewBag.CardPic3ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic3ID);
            ViewBag.CardPic4ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic4ID);
            ViewBag.CardPic5ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic5ID);
            ViewBag.CardPic6ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic6ID);
            ViewBag.FrontPicID = new SelectList(db.Article, "ID", "Header", homeEdit.FrontPicID);
            return View(homeEdit);
        }

        [Authorize(Roles = "Admin")]
        // POST: HomeEdits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FrontPicID,CardPic1ID,CardPic2ID,CardPic3ID,CardPic4ID,CardPic5ID,CardPic6ID")] HomeEdit homeEdit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeEdit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CardPic1ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic1ID);
            ViewBag.CardPic2ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic2ID);
            ViewBag.CardPic3ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic3ID);
            ViewBag.CardPic4ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic4ID);
            ViewBag.CardPic5ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic5ID);
            ViewBag.CardPic6ID = new SelectList(db.Article, "ID", "Header", homeEdit.CardPic6ID);
            ViewBag.FrontPicID = new SelectList(db.Article, "ID", "Header", homeEdit.FrontPicID);
            return View(homeEdit);
        }

        [Authorize(Roles = "Admin")]
        // GET: HomeEdits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeEdit homeEdit = db.HomeEdit.Find(id);
            if (homeEdit == null)
            {
                return HttpNotFound();
            }
            return View(homeEdit);
        }

        [Authorize(Roles = "Admin")]
        // POST: HomeEdits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeEdit homeEdit = db.HomeEdit.Find(id);
            db.HomeEdit.Remove(homeEdit);
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

        public PartialViewResult JustPosted()
        {
            int maxID = db.Article.Max(p => p.ID);
            ViewData["LatestArticle"] = maxID;
            /*Following sends the article db for use in the partial view. Must use partial view to use both HomeEdit and Article models for the startpage (but only Article is used here).*/
            var justPosted = db.Article;
            return PartialView("JustPosted", justPosted.ToList());
        }

        public PartialViewResult MostRead()
        {
            /*Same as above.*/
            var mostRead = db.Article;
            return PartialView("MostRead", mostRead.ToList());
        }

        public ActionResult Magazine()
        {
            return View();
        }

        public ActionResult Subscribe(bool? loggedin)
        {
            /*Used so subscribed users aren't able to subscribe again.*/
            if (User.IsInRole("Subscriber") || User.IsInRole("Admin") || User.IsInRole("Creator"))
            {
                return RedirectToAction("AlreadySubscribed");
            }
            else
            {
                /*Making sure we display correct information regarding locked articles after trying to access a locked article without being subscribed or logged in. Takes the loggedin bool from article controller.*/
                if(loggedin == true)
                {
                    ViewBag.NoSub = true;
                    return View();
                }
                else if(loggedin == null)
                {
                    /*If not coming from locked article (trying to access it)*/
                    if (User.IsInRole("Visitor"))
                    {
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account", new { returnUrl = "/HomeEdits/Subscribe" });
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account", new { returnUrl = "/HomeEdits/Subscribe", loggedin = false });
                }
            }
        }

        [Authorize]
        public ActionResult Payment()
        {
            if (User.IsInRole("Subscriber") || User.IsInRole("Admin") || User.IsInRole("Creator"))
            {
                return RedirectToAction("AlreadySubscribed");
            }
            else
            {
                return View();
            }
        }

        [Authorize]
        public ActionResult ThankYou()
        {
            if (User.IsInRole("Subscriber") || User.IsInRole("Admin") || User.IsInRole("Creator"))
            {
                return RedirectToAction("AlreadySubscribed");
            }
            else
            {
                /*Changing the role of the visitor user when payed.*/
                ApplicationDbContext context;
                context = new ApplicationDbContext();
                UserManager<ApplicationUser> userManager;
                userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                userManager.AddToRole(User.Identity.GetUserId(), "Subscriber");
                userManager.RemoveFromRole(User.Identity.GetUserId(), "Visitor");
                return View();
            }
        }

        public ActionResult AlreadySubscribed()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
