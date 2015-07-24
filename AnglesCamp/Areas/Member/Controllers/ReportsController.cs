using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BOL;

namespace AnglesCamp.Areas.Member.Controllers
{

    [Authorize(Roles="A, U")]
    public class ReportsController : Controller
    {
        ReportBs objBs;
        MembersBs memberObj;
        public ReportsController()
        {
            objBs = new ReportBs();
            memberObj = new MembersBs();
        }

        // GET: Member/Reports
        public ActionResult Index()
        {
            var publicReports = objBs.GetAll().Where(r => r.Visibility == "PUB").ToList();

            return View(publicReports);
        }


        [ChildActionOnly]
        public PartialViewResult GetMyPrivReports()
        {
            string uName = User.Identity.Name;

            BOL.Member member = memberObj.GetAll().Where(m => m.MemberName == uName).FirstOrDefault();


            var myReports = objBs.GetAll().Where(r => r.MemberId == member.MemberId).ToList();

            return PartialView(myReports);
        }
       

    }
}