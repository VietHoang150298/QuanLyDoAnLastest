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
    public class Specialization_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Specialization_Ad
        public ActionResult Index()
        {
            var specializations = db.Specializations.Include(s => s.Industries);
            return View(specializations.ToList());
        }

        // GET: Admin/Specialization_Ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializations specializations = db.Specializations.Find(id);
            if (specializations == null)
            {
                return HttpNotFound();
            }
            return View(specializations);
        }

        // GET: Admin/Specialization_Ad/Create
        public ActionResult Create()
        {
            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "IndustryName");
            return View();
        }

        // POST: Admin/Specialization_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SpecializationId,SpecializationName,IsDelete,IsActive,LastUpdate,IndustryId")] Specializations specializations)
        {
            specializations.IsDelete = false;
            specializations.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Specializations.Add(specializations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "IndustryName", specializations.IndustryId);
            return View(specializations);
        }

        // GET: Admin/Specialization_Ad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializations specializations = db.Specializations.Find(id);
            if (specializations == null)
            {
                return HttpNotFound();
            }
            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "IndustryName", specializations.IndustryId);
            return View(specializations);
        }

        // POST: Admin/Specialization_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SpecializationId,SpecializationName,IsDelete,IsActive,LastUpdate,IndustryId")] Specializations specializations)
        {
            specializations.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(specializations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IndustryId = new SelectList(db.Industries, "IndustryId", "IndustryName", specializations.IndustryId);
            return View(specializations);
        }

        // GET: Admin/Specialization_Ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Specializations specializations = db.Specializations.Find(id);
            if (specializations == null)
            {
                return HttpNotFound();
            }
            return View(specializations);
        }

        // POST: Admin/Specialization_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Specializations specializations = db.Specializations.Find(id);
            db.Specializations.Remove(specializations);
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
