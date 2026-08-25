using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai01.Controllers
{
    public class Bai1Controller : Controller
    {
        // GET: Bai1
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MHList()
        {
            List<string> danhSach = new List<string>();
            danhSach.Add("Trương Mạnh Hùng");
            danhSach.Add("Nguyễn Hải Yến");
            danhSach.Add("Trương Thị Khánh Uyên");
            danhSach.Add("Trương Nguyễn Quỳnh Anh");
            ViewBag.DuLieu = danhSach;
            return View();
        }
    }
}