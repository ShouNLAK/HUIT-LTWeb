using LTWeb03_Bai05.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb03_Bai05.Controllers
{
    public class SachController : Controller
    {
        private static List<Sach> danhSachSach = new List<Sach>()
        {
            new Sach { maSach = "S01", tenSach = "Nisekoi", gia = 90000, anhBia = "/Content/Images/Nisekoi.jpg" },
            new Sach { maSach = "S02", tenSach = "Blue Lock", gia = 100000, anhBia = "/Content/Images/BlueLock.jpg" },
        };

        // GET: Sach/Index
        public ActionResult Index()
        {
            return View();
        }

        // POST: Sach/Login
        [HttpPost]
        public ActionResult Login(Sach obj, HttpPostedFileBase BiaSach)
        {
            if (ModelState.IsValid)
            {
                string fileName = "";
                if (BiaSach != null)
                {
                    fileName = BiaSach.FileName;
                    string uploadDir = "~/Content/Images";
                    string PhysicalPath = Server.MapPath(uploadDir);
                    if (!Directory.Exists(PhysicalPath))
                    {
                        Directory.CreateDirectory(PhysicalPath);
                    }
                    var path = Path.Combine(Server.MapPath(uploadDir), fileName);
                    BiaSach.SaveAs(path);
                    obj.anhBia = "/Content/Images" + "/" + fileName;
                }
                return View(obj);
            }
            return View("Index", obj);
        }

        // POST: Sach/ChiTiet
        [HttpPost]
        public ActionResult ChiTiet(Sach obj, FormCollection form)
        {
            if (form["Password"] == form["Retype-Password"])
            {
                ViewBag.Username = form["Username"];
                ViewBag.Password = form["Password"];

                // Thêm sách mới vào list nếu chưa tồn tại
                if (obj != null && !string.IsNullOrEmpty(obj.maSach) && !danhSachSach.Any(x => x.maSach == obj.maSach))
                {
                    danhSachSach.Add(obj);
                }

                ViewBag.DanhSach = danhSachSach;

                return View(obj);
            }
            return View("Login", obj);
        }
    }
}