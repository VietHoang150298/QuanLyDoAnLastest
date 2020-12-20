using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAnLastest.Models;
using PagedList;

namespace QuanLyDoAnLastest.Areas.Admin.Controllers
{
    public class Faculty_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Facultie_Ad
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Index()
        {
            return View(db.Faculties.ToList());
        }

        public ViewResult PageList(int? page)
        {
            var pagesize = 3;
            var model = db.Faculties.ToList();
            int pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber, pagesize));
        }

        // GET: Admin/Facultie_Ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return HttpNotFound();
            }
            return View(faculties);
        }

        // GET: Admin/Facultie_Ad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Facultie_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FacultyId,FacultyName,Email,Address,PhoneNumber,IsDelete,IsActive,LastUpdate")] Faculties faculties)
        {
            faculties.IsDelete = false;
            faculties.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Faculties.Add(faculties);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(faculties);
        }

        // GET: Admin/Facultie_Ad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return HttpNotFound();
            }
            return View(faculties);
        }

        // POST: Admin/Facultie_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FacultyId,FacultyName,Email,Address,PhoneNumber,IsDelete,IsActive,LastUpdate")] Faculties faculties)
        {
            faculties.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(faculties).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(faculties);
        }

        // GET: Admin/Facultie_Ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Faculties faculties = db.Faculties.Find(id);
            if (faculties == null)
            {
                return HttpNotFound();
            }
            return View(faculties);
        }

        // POST: Admin/Facultie_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Faculties faculties = db.Faculties.Find(id);
            db.Faculties.Remove(faculties);
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
