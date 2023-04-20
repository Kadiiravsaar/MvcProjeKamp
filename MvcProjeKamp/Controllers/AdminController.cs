using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjeKamp.Controllers
{
    public class AdminController : Controller
    {
        Context _context = new Context();
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin a)
        {
            var adminLogin = _context.Admins.FirstOrDefault(x => x.AdminUserName == a.AdminUserName && x.AdminPassword == a.AdminPassword);
            if (adminLogin != null)
            {
                FormsAuthentication.SetAuthCookie(adminLogin.AdminUserName, false);
                Session["AdminUserName"] = adminLogin.AdminUserName;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("AdminLogin");
            }

            return View();
        }
    }
}