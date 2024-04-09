using MyPortfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio1.Controllers
{
    public class ServiceController : Controller
    {
        MyAcademyPortfolioProjectEntities db= new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            var values=db.TblServices.ToList();
            return View(values);
        }

        public ActionResult MakeActive(int id) 
        {
        var values=db.TblServices.Find(id);
            values.Status = true;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult MakePassive(int id)
        {
            var values = db.TblServices.Find(id);
            values.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
    }
}