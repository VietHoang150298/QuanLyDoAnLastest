using QuanLyDoAnLastest.Models;
using QuanLyDoAnLastest.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAnLastest.Areas.Student.Controllers
{
    public class Enrollment_StuController : Controller
    {
        QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();
        // GET: Student/Enrollment_Stu
        public ActionResult Index()
        {
            //List<EnrollmentViewModel> teacher_list = (from teacher_enroll in db.Enrollments
            //                                          join teacher in db.Teachers
            //                                          on teacher_enroll.TeacherCode equals teacher.TeacherCode
            //                                          select new EnrollmentViewModel 
            //                                          { 
            //                                              TeacherCode = teacher.TeacherCode,
            //                                              TeacherName = teacher.TeacherName,
            //                                              TeacherPhoneNumber = teacher.PhoneNumber,
            //                                              GuideStudent = teacher.GuideStudent,
            //                                          }).ToList<EnrollmentViewModel>();
            //return View(teacher_list);
            return View();
        }

    }
}