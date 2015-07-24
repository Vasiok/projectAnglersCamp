using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AnglesCamp.Areas.Security.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Security/Login
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(BOL.Member member)
        {
            try
            {
                if (Membership.ValidateUser(member.MemberName, member.MemberPassword))
                {
                    FormsAuthentication.SetAuthCookie(member.MemberName, false);
                    return RedirectToAction("Index", "Home", new { area = "Common" });
                }
                else
                {
                    TempData["Msg"] = "Login failed ";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                TempData["Msg"] = "Login failed " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        public ActionResult LogOff()
        {

            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home", new { area = "Common"});
        }
    }
}