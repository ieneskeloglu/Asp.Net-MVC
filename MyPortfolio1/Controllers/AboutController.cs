﻿using MyPortfolio.Settings;
using MyPortfolio1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Mvc;

namespace MyPortfolio1.Controllers
{
    [Authorize]
    [SessionTimeOut]
    public class AboutController : Controller
    {
        MyAcademyPortfolioProjectEntities db = new MyAcademyPortfolioProjectEntities();
        public ActionResult Index()
        {
            //ViewBag.user = Session["Username"];
            var values = db.TblAbouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(TblAbouts abouts)
        {
            db.TblAbouts.Add(abouts);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteAbout(int id)
        {
            var about=db.TblAbouts.Find(id);
            db.TblAbouts.Remove(about);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var about = db.TblAbouts.Find(id);
            return View(about);
        }

        [HttpPost]

        public ActionResult UpdateAbout(TblAbouts abouts)
        {
            var value = db.TblAbouts.Find(abouts.AboutId);
            value.ImageUrl=abouts.ImageUrl;
            value.Title=abouts.Title;
            value.Description=abouts.Description;
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}