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
    public class Industry_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Industry_Ad
        public ActionResult Index()
        {
            var industries = db.Industries.Include(i => i.Departments);
            return View(industries.ToList());
        }

        // GET: Admin/Industry_Ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industries industries = db.Industries.Find(id);
            if (industries == null)
            {
                return HttpNotFound();
            }
            return View(industries);
        }

        // GET: Admin/Industry_Ad/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Admin/Industry_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IndustryId,IndustryName,IsDelete,IsActive,LastUpdate,DepartmentId")] Industries industries)
        {
            industries.IsDelete = false;
            industries.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Industries.Add(industries);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", industries.DepartmentId);
            return View(industries);
        }

        // GET: Admin/Industry_Ad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industries industries = db.Industries.Find(id);
            if (industries == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", industries.DepartmentId);
            return View(industries);
        }

        // POST: Admin/Industry_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IndustryId,IndustryName,IsDelete,IsActive,LastUpdate,DepartmentId")] Industries industries)
        {
            industries.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(industries).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(db.Departments, "DepartmentId", "DepartmentName", industries.DepartmentId);
            return View(industries);
        }

        // GET: Admin/Industry_Ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Industries industries = db.Industries.Find(id);
            if (industries == null)
            {
                return HttpNotFound();
            }
            return View(industries);
        }

        // POST: Admin/Industry_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Industries industries = db.Industries.Find(id);
            db.Industries.Remove(industries);
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
