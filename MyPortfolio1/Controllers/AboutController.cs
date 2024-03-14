using MyPortfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio1.Controllers
{
    public class AboutController : Controller
    {
        MyAcademyPortfolioProjectEntities db=new MyAcademyPortfolioProjectEntities();
         public ActionResult Index()
        {
            var values=db.TblAbouts.ToList();
            return View(values);
        }
    }
}