using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Member.Controllers
{

       [Authorize(Roles = "A, U")]
    public class CreateLvLReportController : Controller
    {

           AWLevelBs objBs;

           public CreateLvLReportController()
           {
               objBs = new AWLevelBs();
           }
        // GET: Member/CreateLvLReport
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(ALevelRport report)
        {
            try
            {
                objBs.Insert(report);
                TempData["Msg"] = "Report added succesfuly";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Failed to add the report " + e.Message;
                return RedirectToAction("Index");                
            }


        }


    }
}