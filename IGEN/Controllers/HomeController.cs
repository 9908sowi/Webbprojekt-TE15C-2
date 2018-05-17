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
        private ContentDbContext db = new ContentDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("Index", "HomeEdits");
        }

        public ActionResult About()
        {
            return RedirectToAction("About", "HomeEdits");
        }

        public ActionResult Contact()
        {
            return RedirectToAction("Contact", "HomeEdits");
        }
    }
}
