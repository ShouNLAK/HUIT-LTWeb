using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bai_On_Tap.Models;

namespace Bai_On_Tap.Controllers
{
    public class SanPhamController : Controller
    {
        DataAccess db = new DataAccess();

        public ActionResult Index()
        {
            ViewBag.Title = "Trang chủ - Cửa hàng hoa tươi";
            return View(db.dsSP);
        }

        public ActionResult _DanhMuc()
        {
            return PartialView(db.dsDM);
        }

        public ActionResult TimKiemTheoDanhMuc(int maDM)
        {
            ViewBag.Title = "Trang chủ - Cửa hàng hoa tươi";
            List<SanPham> sanphamtheoDM = db.dsSP.FindAll(x => x.MaDM == maDM);
            return View("Index", sanphamtheoDM);
        }

        public ActionResult TimKiem(string keyword)
        {
            List<SanPham> sanphamtheoTen = db.dsSP.FindAll(x => x.TenSP.ToLower().Contains(keyword.ToLower().Trim()));
            return View("Index", sanphamtheoTen);
        }

        public ActionResult ChiTiet(int id)
        {
            ViewBag.Title = "Chi tiết hoa";
            SanPham sanpham = db.dsSP.Find(x => x.MaSP == id);

            List<SanPham> spLienQuan = db.dsSP.FindAll(x => x.MaDM == sanpham.MaDM && x.MaSP != sanpham.MaSP);
            ViewBag.SanPhamLienQuan = spLienQuan;
            return View(sanpham);
        }
    }
}
