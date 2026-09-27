using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tuan_06.Models;

namespace Tuan_06.Controllers
{
    public class HomeController : Controller
    {
        public DuLieu db = new DuLieu();
        public ActionResult Index(string MaLoai)
        {
            List<SanPham> listSP;

            if (string.IsNullOrWhiteSpace(MaLoai))
                listSP = db.listSP.ToList();
            else
                listSP = db.listSP.Where(x => x.MaLoai.MaLoai == MaLoai).ToList();

            return View(listSP);
        }

        public ActionResult About(string MaSP)
        {
            if (string.IsNullOrWhiteSpace(MaSP))
                return View("Index");
            SanPham sp = db.listSP.FirstOrDefault(x => x.MaSP == MaSP);
            ViewBag.SPLienQuan = db.listSP.Where(x => x.MaLoai == sp.MaLoai && x.MaSP != sp.MaSP).ToList();
            return View(sp);
        }


        public ActionResult TimTheoTuKhoa(string tuKhoa)
        {
            List<SanPham> listSP;
            if (string.IsNullOrWhiteSpace(tuKhoa))
                listSP = db.listSP.ToList();
            else
                listSP = db.listSP.Where(x => x.TenSP.Contains(tuKhoa)).ToList();
            return View("Index", listSP);
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string soDienThoai, string matKhau)
        {
            var kh = db.listKH.FirstOrDefault(x => x.SoDienThoai == soDienThoai && x.MatKhau == matKhau);
            if (kh != null)
            {
                Session["KhachHang"] = kh;
                return View("Index", db.listSP.ToList());
            }
            ViewBag.Error = "Số điện thoại hoặc mật khẩu không đúng!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Remove("KhachHang");
            return View("Index", db.listSP.ToList());
        }

        public ActionResult Search(string MaLoai, decimal? tuGia, decimal? denGia)
        {
            var query = db.listSP.AsQueryable();
            if (!string.IsNullOrEmpty(MaLoai))
                query = query.Where(x => x.MaLoai.MaLoai == MaLoai);
            if (tuGia.HasValue)
                query = query.Where(x => x.Gia >= tuGia.Value);
            if (denGia.HasValue)
                query = query.Where(x => x.Gia <= denGia.Value);
            
            ViewBag.MaLoai = new SelectList(db.listLoai, "MaLoai", "TenLoai", MaLoai);
            return View(query.ToList());
        }

        public ActionResult LichSu()
        {
            var kh = Session["KhachHang"] as Tuan_06.Models.KhachHang;
            var history = db.listHD.Where(x => x.MaKhachHang.MaKhachHang == kh.MaKhachHang).ToList();
            return View(history);
        }

        public ActionResult ChiTietHD(string maHD)
        {
            var details = db.listCT.Where(x => x.MaHoaDon.MaHoaDon == maHD).ToList();
            return View(details);
        }

        [ChildActionOnly]
        public ActionResult _Category()
        {
            return PartialView(db.listLoai);
        }
    }
}