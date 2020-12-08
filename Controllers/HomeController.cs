﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAnLastest.Controllers
{
    public class HomeController : Controller
    {
        //[Authorize( Roles = "RoleTeacher")]
        public ActionResult Index()
        {
            return View();
        }
        //[Authorize(Roles = "RoleTeacher")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        //[Authorize(Roles = "RoleTeacher")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}