using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb_Tuan10.Controllers
{
    public class SachController : Controller
    {
        QLSachEntities db = new QLSachEntities();
        // GET: Sach
        public ActionResult Index(int? ls, int? nxb)
        {
            List<tblSach> list;
            if (ls != null)
            {
                ViewBag.Found = db.tblLoaiSaches.FirstOrDefault(l => l.MaLoai == ls).TenLoai;
                list = db.tblSaches.Where(s => s.LoaiSach == ls).ToList();
            }
            else if (nxb != null)
            {
                ViewBag.Found = db.tblNXBs.FirstOrDefault(n => n.MaNXB == nxb).TenNXB;
                list = db.tblSaches.Where(s => s.NXB == nxb).ToList();
            }
            else { 
                 list = db.tblSaches.ToList();
            }
            
            return View(list);
        }

        public ActionResult Details(int id)
        {
            tblSach sach = db.tblSaches.FirstOrDefault(s => s.MaSach == id);
            ViewBag.DSLQ  = db.tblSaches.Where(s => s.LoaiSach == sach.LoaiSach && s.MaSach != id).ToList();
            return View(sach);
        }

        public ActionResult TimKiem(string TimKiem)
        {
            if (string.IsNullOrEmpty(TimKiem))
            {
                return RedirectToAction("Index");
            }
            List<tblSach> list = db.tblSaches.Where(s => s.TenSach.Contains(TimKiem)).ToList();
            ViewBag.Found = "Kết quả tìm kiếm cho: \"" + TimKiem + "\"";
            return View("Index", list);
        }

        public PartialViewResult TimKiemNangCao()
        {
            ViewBag.Category = new SelectList(db.tblLoaiSaches, "MaLoai", "TenLoai");
            return PartialView();
        }

        public ActionResult TimKiemNangCao_Form(FormCollection form)
        {
            var keyword = form["keyword"];
            string loai = form["loai"];
            var gia = form["Price"];
            List<tblSach> list = db.tblSaches.ToList();

            if (!string.IsNullOrEmpty(keyword))
            {
                list = list.Where(s => s.TenSach.ToLower().Contains(keyword.ToLower().Trim())).ToList();
            }
            if (!string.IsNullOrEmpty(loai))
            {
                int maLoai = int.Parse(loai);
                list = list.Where(s => s.LoaiSach == maLoai).ToList();
            }
            if (!string.IsNullOrEmpty(gia))
            {
                switch (gia)
                {
                    case "0":
                        list = list.Where(s => s.GiaBan >= 0 && s.GiaBan <= 10000).ToList();
                        break;
                    case "1":
                        list = list.Where(s => s.GiaBan > 10000 && s.GiaBan <= 20000).ToList();
                        break;
                    case "2":
                        list = list.Where(s => s.GiaBan > 20000 && s.GiaBan <= 30000).ToList();
                        break;
                    case "3":
                        list = list.Where(s => s.GiaBan > 40000).ToList();
                        break;
                }
            }

            return View("Index", list);
        }


    }
}