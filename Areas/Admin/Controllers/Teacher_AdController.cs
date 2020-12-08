using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyDoAnLastest.Models;

namespace QuanLyDoAnLastest.Areas.Admin.Controllers
{
    public class Teacher_AdController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();

        // GET: Admin/Teacher_Ad
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Specializations);
            return View(teachers.ToList());
        }
        //private void UploadExcelFile(HttpPostedFileBase file)
        //{
        //    string _FileName = "File Name";

        //    string _path = Path.Combine(Server.MapPath("~/Uploads/Excels"), _FileName);

        //    file.SaveAs(_path);
        //}
        //public ActionResult DownloadFile()
        //{
        //    string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/Excels/";

        //    byte[] fileBytes = System.IO.File.ReadAllBytes(path + "TeacherExcel.xlsx");

        //    string fileName = "FileDownLoad.xlsx";
        //    return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        //}
        //public DataTable ReadDataFromExcelFile(string filepath)
        //{
        //    string connectionString = "";
        //    string fileExtention = filepath.Substring(filepath.Length - 4).ToLower();
        //    if (fileExtention.IndexOf("xlsx") == 0)
        //    {
        //        connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source =" + filepath + ";Extended Properties=\"Excel 12.0 Xml;HDR=NO\"";
        //    }
        //    else if (fileExtention.IndexOf("xls") == 0)
        //    {
        //        connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filepath + ";Extended Properties=Excel 8.0";
        //    }

        //    // Tạo đối tượng kết nối
        //    OleDbConnection oledbConn = new OleDbConnection(connectionString);
        //    DataTable data = null;
        //    try
        //    {
        //        // Mở kết nối
        //        oledbConn.Open();

        //        // Tạo đối tượng OleDBCommand và query data từ sheet có tên "Sheet1"
        //        OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn);

        //        // Tạo đối tượng OleDbDataAdapter để thực thi việc query lấy dữ liệu từ tập tin excel
        //        OleDbDataAdapter oleda = new OleDbDataAdapter();

        //        oleda.SelectCommand = cmd;

        //        // Tạo đối tượng DataSet để hứng dữ liệu từ tập tin excel
        //        DataSet ds = new DataSet();

        //        // Đổ đữ liệu từ tập excel vào DataSet
        //        oleda.Fill(ds);

        //        data = ds.Tables[0];
        //    }
        //    catch
        //    {
        //    }
        //    finally
        //    {
        //        // Đóng chuỗi kết nối
        //        oledbConn.Close();
        //    }
        //    return data;
        //}
        //private void CopyDataByBulk(DataTable dt)
        //{
        //    //lay ket noi voi database luu trong file webconfig
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB Context"].ConnectionString);
        //    SqlBulkCopy bulkcopy = new SqlBulkCopy(con);
        //    bulkcopy.DestinationTableName = "Teachers";
        //    bulkcopy.ColumnMappings.Add(0, "TeacherCode");
        //    bulkcopy.ColumnMappings.Add(1, "TeacherName");
        //    bulkcopy.ColumnMappings.Add(2, "Note");
        //    bulkcopy.ColumnMappings.Add(3, "SpecializationId");
        //    bulkcopy.ColumnMappings.Add(4, "Position");
        //    bulkcopy.ColumnMappings.Add(5, "PhoneNumber");
        //    bulkcopy.ColumnMappings.Add(6, "GuideStudent");
        //    bulkcopy.ColumnMappings.Add(7, "LastUpdate");

        //    con.Open();
        //    bulkcopy.WriteToServer(dt);
        //    con.Close();
        //}

        // GET: Admin/Teacher_Ad/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // GET: Admin/Teacher_Ad/Create
        public ActionResult Create()
        {
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName");
            return View();
        }

        // POST: Admin/Teacher_Ad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherCode,TeacherName,Position,PhoneNumber,Note,LastUpdate,GuideStudent,SpecializationId")] Teachers teachers)
        {
            teachers.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teachers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", teachers.SpecializationId);
            return View(teachers);
        }

        // GET: Admin/Teacher_Ad/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", teachers.SpecializationId);
            return View(teachers);
        }

        // POST: Admin/Teacher_Ad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherCode,TeacherName,Position,PhoneNumber,Note,LastUpdate,GuideStudent,SpecializationId")] Teachers teachers)
        {
            teachers.LastUpdate = DateTime.Now;
            if (ModelState.IsValid)
            {
                db.Entry(teachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SpecializationId = new SelectList(db.Specializations, "SpecializationId", "SpecializationName", teachers.SpecializationId);
            return View(teachers);
        }

        // GET: Admin/Teacher_Ad/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teachers teachers = db.Teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        // POST: Admin/Teacher_Ad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Teachers teachers = db.Teachers.Find(id);
            db.Teachers.Remove(teachers);
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
