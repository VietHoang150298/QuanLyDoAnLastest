using QuanLyDoAnLastest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAnLastest.Controllers
{
    public class Teacher_HomeController : Controller
    {
        QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();
        // GET: Teacher_Home
        public ActionResult Index()
        {
            var teacher_list = from teacher in db.Teachers
                               
                               select teacher;
            return View(teacher_list);
        }
    }
}