using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tuan_08_Bai2.Controllers
{
    public class SachController : Controller
    {
        // GET: Sach
        QLSachEntities DB = new QLSachEntities();
        // GET: News
        public ActionResult Index()
        {
            return View(DB.tblSach);
        }

        public ActionResult Add()
        {
            ViewBag.Category = new SelectList(DB.tblLoaiSach, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public ActionResult CreateOnSubmit(tblSach sach, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                DB.tblSach.Add(sach);
                DB.SaveChanges();

                if (Image != null && Image.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(Image.FileName);
                    string Dir = "/Content/Images/";
                    string physicalDir = Server.MapPath(Dir);
                    if (!Directory.Exists(physicalDir))
                    {
                        Directory.CreateDirectory(physicalDir);
                    }
                    string path = Path.Combine(physicalDir, fileName);
                    Image.SaveAs(path);
                    tblHinhAnh hinhAnh = new tblHinhAnh();
                    hinhAnh.MaSach = sach.MaSach;
                    hinhAnh.HinhAnh = Dir + fileName;
                    DB.tblHinhAnh.Add(hinhAnh);
                    DB.SaveChanges();
                }

                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(DB.tblLoaiSach, "MaLoai", "TenLoai", sach.LoaiSach);
            return View("Add", sach);
        }

    }
}