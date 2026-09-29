using _22_NguyenLeAnhKhoa_2001240206.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _22_NguyenLeAnhKhoa_2001240206.Controllers
{
    public class HomeController : Controller
    {
        DataSQL db = new DataSQL();
        public ActionResult Index()
        {
            ViewBag.MSSV = "2001240206";
            ViewBag.HoVaTen = "Nguyễn Lê Anh Khoa"; 
            List<String> Hobby = new List<string>{ "Xem phim", "Nghe nhạc", "Luyện code" };
            ViewBag.Hobby = Hobby;
            return View();
        }

        public ActionResult About(int ProductID)
        {
            ViewBag.Title = "Chi tiết sản phẩm";
            Products sanpham = db.DS_SanPham.Find(x => x.ProductID == ProductID);
            List<Products> spLienQuan = db.DS_SanPham.FindAll(x => x.CategoryID == sanpham.CategoryID && x.ProductID != sanpham.ProductID);
            ViewBag.SanPhamLienQuan = spLienQuan;
            ViewBag.Color = db.DS_MauKinh;
            return View(sanpham);
        }

        public ActionResult Product()
        {
            return View(db.DS_SanPham);
        }

        public ActionResult _DanhMuc()
        {
            return PartialView(db.DS_DanhMuc);
        }

        public ActionResult TimKiemTheoDanhMuc(int CategoryID)
        {
            ViewBag.Title = "Trang chủ - Cửa hàng hoa tươi";
            List<Products> sanphamtheoDM = db.DS_SanPham.FindAll(x => x.CategoryID.CategoryID == CategoryID);
            return View("Product", sanphamtheoDM);
        }

        public ActionResult TimKiem(string keyword)
        {
            List<Products> sanphamtheoTen = db.DS_SanPham.FindAll(x => x.ProductName.ToLower().Contains(keyword.ToLower().Trim()));
            return View("Product", sanphamtheoTen);
        }
    }
}