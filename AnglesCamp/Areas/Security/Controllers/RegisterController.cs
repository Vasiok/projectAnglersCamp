using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace AnglesCamp.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {

        MembersBs objBs;

        public RegisterController()
        {
            objBs = new MembersBs();
        }
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BOL.Member member)
        {           
            try
            {
                if (ModelState.IsValid)
                {
                    
                    member.MemberClub = "NONE";
                    member.MemberPicture = "~/UploadIMG/default_avatar.png";
                    member.MemberType = "U";

                    objBs.Insert(member);

                    TempData["Msg"] = "Registered Successfuly";
                    return RedirectToAction("Index"); 
                }
                else
                {
                    return View("Index");
                }
            }
            catch (Exception e)
            {
                TempData["Msg"] = "Registration failed" + e.Message;
                return RedirectToAction("Index");
            }
        }


    }
}