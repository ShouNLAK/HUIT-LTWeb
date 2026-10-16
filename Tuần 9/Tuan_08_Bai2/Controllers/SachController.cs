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
        QLSachEntities DB = new QLSachEntities();

        public ActionResult Index()
        {
            return View(DB.tblSach);
        }

        public ActionResult Add()
        {
            ViewBag.Category = new SelectList(DB.tblLoaiSach, "MaLoai", "TenLoai");
            return View();
        }

        public ActionResult Edit(int id)
        {
            var sach = DB.tblSach.Find(id);
            ViewBag.Category = new SelectList(DB.tblLoaiSach, "MaLoai", "TenLoai", sach.LoaiSach);
            return View(sach);
        }

        public ActionResult Delete(int id)
        {
            return View(DB.tblSach.Find(id));
        }

        public ActionResult Details(int id)
        {
            return View(DB.tblSach.Find(id));
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

        [HttpPost]
        public ActionResult EditOnSubmit(tblSach sach, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var existingSach = DB.tblSach.Find(sach.MaSach);
                if (existingSach != null)
                {
                    existingSach.TenSach = sach.TenSach;
                    existingSach.NamXB = sach.NamXB;
                    existingSach.SoTrang = sach.SoTrang;
                    existingSach.GiaBan = sach.GiaBan;
                    existingSach.NoiDung = sach.NoiDung;
                    existingSach.LoaiSach = sach.LoaiSach;
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
                        var existingHinhAnh = DB.tblHinhAnh.FirstOrDefault(x => x.MaSach == sach.MaSach);
                        if (existingHinhAnh != null)
                        {
                            existingHinhAnh.HinhAnh = Dir + fileName;
                        }
                        else
                        {
                            tblHinhAnh hinhAnh = new tblHinhAnh();
                            hinhAnh.MaSach = sach.MaSach;
                            hinhAnh.HinhAnh = Dir + fileName;
                            DB.tblHinhAnh.Add(hinhAnh);
                        }
                    }
                    DB.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(DB.tblLoaiSach, "MaLoai", "TenLoai", sach.LoaiSach);
            return View("Edit", sach);
        }

        [HttpPost]
        public ActionResult DeleteOnSubmit(tblSach sach)
        {
            var existingSach = DB.tblSach.Find(sach.MaSach);
            if (existingSach != null)
            {
                var relatedDetails = DB.tblChiTietHoaDon.Where(x => x.MaSach == sach.MaSach).ToList();
                if (relatedDetails.Count > 0)
                {
                    DB.tblChiTietHoaDon.RemoveRange(relatedDetails);
                }

                var existingHinhAnh = DB.tblHinhAnh.Where(x => x.MaSach == sach.MaSach).ToList();
                if (existingHinhAnh.Count > 0)
                {
                    DB.tblHinhAnh.RemoveRange(existingHinhAnh);
                }
                DB.tblSach.Remove(existingSach);
                DB.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}