using MyPortfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio1.Controllers
{
    public class ProjectController : Controller
    {
        MyAcademyPortfolioProjectEntities db=new MyAcademyPortfolioProjectEntities();   

        // GET: Project
        public ActionResult Index()
        {
            var values=db.TblProjects.ToList();
            return View(values);
        }

        public ActionResult AddProject()
        {
            var categories=db.TblCategories.ToList();
            List<SelectListItem> categorylist=(from x in categories select new SelectListItem
            {
                Text=x.CategoryName,
                Value=x.CategoryId.ToString()
            }).ToList();


            ViewBag.Categories = categorylist;

            return View();
        }

        [HttpPost]
        public ActionResult AddProject(TblProjects project)
        {
            db.TblProjects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]

        public ActionResult UpdateProject(int id)
        {
            var categories = db.TblCategories.ToList();
            List<SelectListItem> categorylist = (from x in categories
                                                 select new SelectListItem
                                                 {
                                                     Text = x.CategoryName,
                                                     Value = x.CategoryId.ToString()
                                                 }).ToList();


            ViewBag.Categories = categorylist;

            var value = db.TblProjects.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(TblProjects project)
        {
            var value = db.TblProjects.Find(project.ProjectId);
            value.ProjectName = project.ProjectName;
            value.ImageUrl = project.ImageUrl;
            value.GithubUrl = project.GithubUrl;
            value.CategoryId = project.CategoryId;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProject(int id)
        {
            var value=db.TblProjects.Find(id);
            db.TblProjects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}