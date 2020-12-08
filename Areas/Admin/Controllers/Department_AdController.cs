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
    public class Department_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Department_Ad
        public ActionResult Index()
        {
            var departments = db.Departments.Include(d => d.Faculties);
            return View(departments.ToList());
        }

        // GET: Admin/Department_Ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // GET: Admin/Department_Ad/Create
        public ActionResult Create()
        {
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName");
            return View();
        }

        // POST: Admin/Department_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentId,DepartmentName,Email,Address,PhoneNumber,IsDelete,IsActive,LastUpdate,FacultyId")] Departments departments)
        {
            departments.IsDelete = false;
            departments.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Departments.Add(departments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", departments.FacultyId);
            return View(departments);
        }

        // GET: Admin/Department_Ad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", departments.FacultyId);
            return View(departments);
        }

        // POST: Admin/Department_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentId,DepartmentName,Email,Address,PhoneNumber,IsDelete,IsActive,LastUpdate,FacultyId")] Departments departments)
        {
            departments.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(departments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FacultyId = new SelectList(db.Faculties, "FacultyId", "FacultyName", departments.FacultyId);
            return View(departments);
        }

        // GET: Admin/Department_Ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departments departments = db.Departments.Find(id);
            if (departments == null)
            {
                return HttpNotFound();
            }
            return View(departments);
        }

        // POST: Admin/Department_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departments departments = db.Departments.Find(id);
            db.Departments.Remove(departments);
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
