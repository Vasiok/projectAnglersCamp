using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace AnglesCamp.Areas.Member.Controllers
{
    [Authorize(Roles = "A, U")]
    public class ProfileController : Controller
    {

        MembersBs objBs;

        public ProfileController()
        {
            objBs = new MembersBs();
        }


        // GET: Member/Profile
        public ActionResult Index()
        {
            MembersBs objBs = new MembersBs();
            string userName = User.Identity.Name;

            BOL.Member member = objBs.GetAll().Where(u => u.MemberName == userName).FirstOrDefault();

            return View(member);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {

            BOL.Member member = objBs.GetById(id);

            return View(member);
        }


        [HttpPost]
        public ActionResult Edit(BOL.Member member)
        {            
            try
            {

                //string appPath;
                //string memberPicPath = member.MemberPicture;

                //if (file != null && file.ContentLength > 0)
                //{
                //    var fileName = Path.GetFileName(file.FileName);

                //    appPath = Path.Combine(Server.MapPath("~/UploadIMG"), fileName);
                //    file.SaveAs(appPath);
                //    memberPicPath = "~/UploadIMG/" + file.FileName;
                //}

                
                //BOL.Member mbr = member;
                //mbr.MemberPicture = memberPicPath;

                objBs.Update(member);
                TempData["Msg"] = "Profile updated succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Update failed" + e.Message;
                return RedirectToAction("Index");
            }
            //return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult EditPicture(int id)
        {
            BOL.Member member = objBs.GetById(id);

            return View(member);
        }

        [HttpPost]
        public ActionResult EditPicture(HttpPostedFileBase file,  BOL.Member member)
        {
            try
            {

                string appPath;
                string memberPicPath = member.MemberPicture;

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    appPath = Path.Combine(Server.MapPath("~/UploadIMG"), fileName);
                    file.SaveAs(appPath);
                    memberPicPath = "~/UploadIMG/" + file.FileName;
                }


                BOL.Member mbr = member;
                mbr.MemberPicture = memberPicPath;

                objBs.Update(mbr);
                TempData["Msg"] = "Profile updated succesfully";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                TempData["Msg"] = "Update failed" + e.Message;
                return RedirectToAction("Index");
            }
        }
    }
}