using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Common
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        // GET: Common/Home
        public ActionResult Index()
        {
            NewsJson news = new NewsJson();

            var results = news.GetFromKimono();

            ViewData["newsData"] = results;


            return View();
        }
    }
}