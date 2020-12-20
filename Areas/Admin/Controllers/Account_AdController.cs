using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAnLastest.Models;
using QuanLyDoAnLastest.Models.Process;

namespace QuanLyDoAnLastest.Areas.Admin.Controllers
{
    public class Account_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();
        StringProcess strPro = new StringProcess();

        // GET: Admin/Account_Ad
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Index()
        {
            var accounts = db.Accounts.Include(a => a.Roles).Include(a => a.Students).Include(a => a.Teachers);
            return View(accounts.ToList());
        }

        // GET: Admin/Account_Ad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // GET: Admin/Account_Ad/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName");
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName");
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName");
            return View();
        }

        // POST: Admin/Account_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccountId,UserName,Email,Password,ConfirmPassword,RoleId,StudentCode,TeacherCode")] Accounts accounts)
        {
            string strMD5 = strPro.GetMD5(accounts.Password);
            if (accounts.Password == accounts.ConfirmPassword)
            {
                accounts.Password = strMD5;
                accounts.ConfirmPassword = strMD5;
            }
            if (ModelState.IsValid)
            {
                db.Accounts.Add(accounts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", accounts.RoleId);
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", accounts.StudentCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", accounts.TeacherCode);
            return View(accounts);
        }

        // GET: Admin/Account_Ad/Edit/5
        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", accounts.RoleId);
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", accounts.StudentCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", accounts.TeacherCode);
            return View(accounts);
        }

        // POST: Admin/Account_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccountId,UserName,Email,Password,ConfirmPassword,RoleId,StudentCode,TeacherCode")] Accounts accounts)
        {
            string strMD5 = strPro.GetMD5(accounts.Password);
            if (accounts.Password == accounts.ConfirmPassword)
            {
                accounts.Password = strMD5;
                accounts.ConfirmPassword = strMD5;
            }
            if (ModelState.IsValid)
            {
                db.Entry(accounts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "RoleId", "RoleName", accounts.RoleId);
            ViewBag.StudentCode = new SelectList(db.Students, "StudentCode", "StudentName", accounts.StudentCode);
            ViewBag.TeacherCode = new SelectList(db.Teachers, "TeacherCode", "TeacherName", accounts.TeacherCode);
            return View(accounts);
        }

        // GET: Admin/Account_Ad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accounts accounts = db.Accounts.Find(id);
            if (accounts == null)
            {
                return HttpNotFound();
            }
            return View(accounts);
        }

        // POST: Admin/Account_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accounts accounts = db.Accounts.Find(id);
            db.Accounts.Remove(accounts);
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
