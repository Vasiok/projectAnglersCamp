using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Member.Controllers
{
    [Authorize(Roles = "A, U")]
    public class ForumController : Controller
    {
        // GET: Member/Forum
        public ActionResult Index()
        {
            return View();
        }
    }
}