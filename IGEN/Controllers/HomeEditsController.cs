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
    public class HomeEditsController : Controller
    {
        private ContentDbContext db = new ContentDbContext();

        // GET: HomeEdits
        public ActionResult Index()
        {
            var homeEdit = db.HomeEdit.Include(h => h.CardPic1).Include(h => h.CardPic2).Include(h => h.CardPic3).Include(h => h.CardPic4).Include(h => h.CardPic5).Include(h => h.CardPic6).Include(h => h.FrontPic);
            return View(homeEdit.ToList());
        }

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
    }
}
