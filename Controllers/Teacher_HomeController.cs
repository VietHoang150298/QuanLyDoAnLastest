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
        [Authorize(Roles = "RoleTeacher")]
        public ActionResult ManageStudent()
        {
            var guideStu = from enrol in db.Enrollments
                           where enrol.TeacherCode == "111"
                           //join teach in db.Teachers
                           //on enrol.TeacherCode equals teach.TeacherCode
                           select enrol;
            return View(guideStu);
        }
    }
}