using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAnLastest.Models;

namespace QuanLyDoAnLastest.Controllers
{
    public class Enrollment_HomeController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Enrollment_Home
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Students).Include(e => e.SubjectStudents).Include(e => e.Teachers);
            return View(enrollments.ToList());
        }

        // GET: Enrollment_Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // GET: Enrollment_Home/Create
        [Authorize(Roles = "RoleStudent")]
        public ActionResult Create()
        {
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName");
            ViewBag.SubStuCode = new SelectList(db.SubjectStudents, "SubStuCode", "SubStuName");
            //ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName");
            ViewBag.Teachers = db.Teachers.ToList();
            return View();
        }

        // POST: Enrollment_Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,LastUpdate,StudentCode,TeacherCode,SubStuCode")] Enrollment enrollment)
        {
            enrollment.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                enrollment.StudentCode = Session["StudentCode"].ToString();
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", enrollment.StudentCode);
            ViewBag.SubStuCode = new SelectList(db.SubjectStudents, "SubStuCode", "SubStuName", enrollment.SubStuCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", enrollment.TeacherCode);
            return View(enrollment);
        }

        // GET: Enrollment_Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", enrollment.StudentCode);
            ViewBag.SubStuCode = new SelectList(db.SubjectStudents, "SubStuCode", "SubStuName", enrollment.SubStuCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", enrollment.TeacherCode);
            return View(enrollment);
        }

        // POST: Enrollment_Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,LastUpdate,StudentCode,TeacherCode,SubStuCode")] Enrollment enrollment)
        {
            enrollment.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", enrollment.StudentCode);
            ViewBag.SubStuCode = new SelectList(db.SubjectStudents, "SubStuCode", "SubStuName", enrollment.SubStuCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", enrollment.TeacherCode);
            return View(enrollment);
        }

        // GET: Enrollment_Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enrollment enrollment = db.Enrollments.Find(id);
            if (enrollment == null)
            {
                return HttpNotFound();
            }
            return View(enrollment);
        }

        // POST: Enrollment_Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Enrollment enrollment = db.Enrollments.Find(id);
            db.Enrollments.Remove(enrollment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
