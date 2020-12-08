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
    public class Class_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Class_Ad
        public ActionResult Index()
        {
            var classes = db.Classes.Include(c => c.Specializations);
            return View(classes.ToList());
        }

        // GET: Admin/Class_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // GET: Admin/Class_Ad/Create
        public ActionResult Create()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName");
            return View();
        }

        // POST: Admin/Class_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassCode,ClassName,LastUpdate,IsDelete,IsActive,SpecializationId")] Classes classes)
        {
            classes.LastUpdate = DateTime.Now;
            classes.IsDelete = false;
            if (ModelState.IsValid)
            {
                db.Classes.Add(classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", classes.SpecializationId);
            return View(classes);
        }

        // GET: Admin/Class_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", classes.SpecializationId);
            return View(classes);
        }

        // POST: Admin/Class_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClassCode,ClassName,LastUpdate,IsDelete,IsActive,SpecializationId")] Classes classes)
        {
            classes.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", classes.SpecializationId);
            return View(classes);
        }

        // GET: Admin/Class_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Classes classes = db.Classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        // POST: Admin/Class_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Classes classes = db.Classes.Find(id);
            db.Classes.Remove(classes);
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
