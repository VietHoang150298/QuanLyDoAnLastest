using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyDoAnLastest.Areas.Admin.Controllers
{
    public class Home_AdController : Controller
    {
        // GET: Admin/Home_Ad
        [Authorize(Roles = "RoleAdmin")]
        public ActionResult Index()
        {
            return View();
        }
    }
}