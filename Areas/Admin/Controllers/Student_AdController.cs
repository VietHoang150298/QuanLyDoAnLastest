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
    public class Student_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Student_Ad
        public ActionResult Index()
        {
            var students = db.Students.Include(s => s.Classes);
            return View(students.ToList());
        }

        // GET: Admin/Student_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // GET: Admin/Student_Ad/Create
        public ActionResult Create()
        {
            ViewBag.ClassCode = new SelectList(db.Classes, "ClassCode", "ClassName");
            return View();
        }

        // POST: Admin/Student_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentCode,StudentName,Note,LastUpdate,PhoneNumber,ClassCode")] Students students)
        {
            students.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassCode = new SelectList(db.Classes, "ClassCode", "ClassName", students.ClassCode);
            return View(students);
        }

        // GET: Admin/Student_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassCode = new SelectList(db.Classes, "ClassCode", "ClassName", students.ClassCode);
            return View(students);
        }

        // POST: Admin/Student_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentCode,StudentName,Note,LastUpdate,PhoneNumber,ClassCode")] Students students)
        {
            students.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassCode = new SelectList(db.Classes, "ClassCode", "ClassName", students.ClassCode);
            return View(students);
        }

        // GET: Admin/Student_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Students students = db.Students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        // POST: Admin/Student_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Students students = db.Students.Find(id);
            db.Students.Remove(students);
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
