using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnglesCamp.Areas.Member.Controllers
{
    [Authorize(Roles = "A, U")]
    public class CreateReportController : Controller
    {

        MembersBs memberObj;
        ReportBs objBs;

        String filePath = "~/UploadIMG/";
        String noImageName = "no_image_thumb.gif";

        public CreateReportController()
        {
            memberObj = new MembersBs();
            objBs = new ReportBs();
        }

        // GET: Member/CreateReport
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Report report)
        {
            try
            {                
                

                string reportPicPath = "";
                
                if (TempData["path"] == null || TempData["path"] == "")
                {
                    reportPicPath = filePath + noImageName;
                    report.Picture = reportPicPath;
                }
                else
                {
                    report.Picture = TempData["path"].ToString();
                    TempData["path"] = "";
                }

                BOL.Member member = memberObj.GetAll().Where(m => m.MemberName == User.Identity.Name).FirstOrDefault();

                report.MemberId = member.MemberId;
                objBs.Insert(report);

                TempData["Msg"] = "New report created succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Update failed" + e.Message;
                return RedirectToAction("Index");
            }
            
        }


        [HttpPost]
        public ActionResult UploadImage(HttpPostedFileBase file)
        {
            if(file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var appPath = Path.Combine(Server.MapPath("~/UploadIMG"), fileName);
                file.SaveAs(appPath);

                filePath = filePath + fileName;

                TempData["path"] = filePath;
            }

            return RedirectToAction("Index");
        }
    }
}