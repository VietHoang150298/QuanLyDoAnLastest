using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using QuanLyDoAnLastest.Models;
using QuanLyDoAnLastest.Models.Process;

namespace QuanLyDoAnLastest.Controllers
{
    public class AuthorizeController : Controller
    {
        private QuanLyDoAnDbContext db = new QuanLyDoAnDbContext();
        private int CheckSession()
        {
            using (var db = new QuanLyDoAnDbContext())
            {
                var user = HttpContext.Session["idUser"];
                if (user != null)
                {
                    //var role = db.Accounts.Find(user.ToString()).RoleId;
                    var role = db.Accounts.Where(m => m.UserName == user.ToString()).FirstOrDefault().RoleId;
                    if (role != null)
                    {
                        if (role.ToString() == "RoleTeacher")
                        {
                            return 1;
                        }
                        else if (role.ToString() == "RoleAdmin")
                        {
                            return 2;
                        }
                        else if (role.ToString() == "RoleStudent")
                        {
                            return 3;
                        }
                    }
                }
            }
            return 0;
        }
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (CheckSession() == 1)
            {
                return RedirectToAction("ManageStudent", "Teacher_Home");
            }
            else if (CheckSession() == 2)
            {
                return RedirectToAction("Index", "Faculty_Ad", new { Area = "Admin" });
            }
            else if (CheckSession() == 3)
            {
                return RedirectToAction("Create", "Enrollment_Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Accounts acc, string returnUrl)
        {
            StringProcess strPro = new StringProcess();
            try
            {
                if (!string.IsNullOrEmpty(acc.UserName) && !string.IsNullOrEmpty(acc.Password))
                {

                    using (var db = new QuanLyDoAnDbContext())
                    {
                        var passToMD5 = strPro.GetMD5(acc.Password);
                        var account = db.Accounts.Where(m => m.UserName.Equals(acc.UserName) && m.Password.Equals(passToMD5));
                        if (account.Count() == 1)
                        {
                            FormsAuthentication.SetAuthCookie(acc.UserName, false);
                            Session["idUser"] = acc.UserName;
                            Session["roleUser"] = acc.RoleId;
                            Session["StudentCode"] = account.FirstOrDefault().StudentCode;
                            Session["TeacherCode"] = account.FirstOrDefault().TeacherCode;
                            Response.Cookies.Add(new HttpCookie("userCookie", acc.UserName));
                            Response.Cookies.Add(new HttpCookie("roleCookie", acc.RoleId));
                            return RedirectToLocal(returnUrl);
                        }
                        ModelState.AddModelError("", "Thông tin đăng nhập chưa chính xác");
                    }
                }
                ModelState.AddModelError("", "Username and password is required.");
            }
            catch
            {
                ModelState.AddModelError("", "Hệ thống đang được bảo trì, vui lòng liên hệ với quản trị viên");
            }
            return View(acc);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || returnUrl == "/")
            {
                if (CheckSession() == 1)
                {
                    return RedirectToAction("ManageStudent", "Teacher_Home");
                }
                else if (CheckSession() == 2)
                {
                    return RedirectToAction("Index", "Faculty_Ad", new { Area = "Admin" });
                }
                else if (CheckSession() == 3)
                {
                    return RedirectToAction("Create", "Enrollment_Home");
                }
            }
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Faculty_Ad", new { Area = "Admin" });
            }
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return Redirect("/Authorize/Login");
        }
    }
}