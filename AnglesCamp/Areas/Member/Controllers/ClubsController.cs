using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Member.Controllers
{
    [Authorize(Roles = "A, U")]
    public class ClubsController : Controller
    {
        // GET: Member/Clubs
        public ActionResult Index()
        {
            return View();
        }
    }
}