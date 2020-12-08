using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAnLastest.Models;

namespace QuanLyDoAnLastest.Areas.Admin.Controllers
{
    public class Enrollment_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Enrollment_Ad
        public ActionResult Index()
        {
            var enrollments = db.Enrollments.Include(e => e.Students).Include(e => e.Teachers);
            return View(enrollments.ToList());
        }

        // GET: Admin/Enrollment_Ad/Details/5
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

        // GET: Admin/Enrollment_Ad/Create
        public ActionResult Create()
        {
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName");
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName");
            return View();
        }

        // POST: Admin/Enrollment_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EnrollmentId,LastUpdate,StudentCode,TeacherCode")] Enrollment enrollment)
        {
            enrollment.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Enrollments.Add(enrollment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", enrollment.StudentCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", enrollment.TeacherCode);
            return View(enrollment);
        }

        // GET: Admin/Enrollment_Ad/Edit/5
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
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", enrollment.TeacherCode);
            return View(enrollment);
        }

        // POST: Admin/Enrollment_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EnrollmentId,LastUpdate,StudentCode,TeacherCode")] Enrollment enrollment)
        {
            enrollment.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(enrollment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", enrollment.StudentCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", enrollment.TeacherCode);
            return View(enrollment);
        }

        // GET: Admin/Enrollment_Ad/Delete/5
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

        // POST: Admin/Enrollment_Ad/Delete/5
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
