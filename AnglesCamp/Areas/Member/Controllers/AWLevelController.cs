using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Member.Controllers
{
    [Authorize(Roles = "A, U")]
    public class AWLevelController : Controller
    {

        AWLevelBs objBs;

        public AWLevelController()
        {
            objBs = new AWLevelBs();
        }
        // GET: Member/AWLevel
        public ActionResult Index()
        {
            var lvlReps = objBs.GetAll().ToList();

            return View(lvlReps);
        }
    }
}