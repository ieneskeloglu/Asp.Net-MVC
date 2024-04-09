using MyPortfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MyPortfolio1.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        MyAcademyPortfolioProjectEntities db=new MyAcademyPortfolioProjectEntities();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmins admin)
        {
            var value=db.TblAdmins.FirstOrDefault(x=>x.Username==admin.Username && x.Password==admin.Password);
            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = value.Username;
                return RedirectToAction("Index", "About");
            }
            else
            {
                ModelState.AddModelError("","Kullanıcı adı veya şifre yanlış");
                return View();
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();  
            Session.Abandon();
            return RedirectToAction("Index", "Default");
        }
    }
}