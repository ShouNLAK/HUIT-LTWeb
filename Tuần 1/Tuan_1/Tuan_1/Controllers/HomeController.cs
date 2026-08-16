using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tuan_1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Đây là trang About";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Đây là trang liên hệ";

            return View();
        }

        public ActionResult HienThi(string id)
        {
            ViewData["id"] = id;
            ViewBag.id = id;
            return View();
        }

        public ActionResult Index3(string id, string name)
        {
            ViewData["id"] = id;
            ViewData["name"] = name;
            return View();
        }
    }
}