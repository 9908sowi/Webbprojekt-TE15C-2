using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using IGEN.Models;

namespace IGEN.Controllers
{
    public class HomeController : Controller
    {
        private ArticleDbContext db = new ArticleDbContext();

        public ActionResult Index(string search)
        {
            var articles = db.Articles.Include(p => p.Game);
            if (!String.IsNullOrEmpty(search))
            {
                articles = articles.Where(p => p.Name.Contains(search));
            }
            return View(articles.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
