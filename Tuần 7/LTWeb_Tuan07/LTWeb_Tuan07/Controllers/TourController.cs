using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTWeb_Tuan07.Models;

namespace LTWeb_Tuan07.Controllers
{
    public class TourController : Controller
    {
        DataSQL db = new DataSQL();

        public ActionResult Index()
        {
            return View(db.DS_Tour);
        }

        [ChildActionOnly]
        public ActionResult _DanhMuc()
        {
            return PartialView(db.DS_DanhMuc);
        }

        public ActionResult TimKiemTheoDanhMuc(int maDM)
        {
            List<Tour> ds = db.DS_Tour.FindAll(x => x.MaDM != null && x.MaDM.MaDM == maDM);
            return View("Index", ds);
        }

        public ActionResult TimKiem(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return View("Index", db.DS_Tour);

            List<Tour> ds = db.DS_Tour.FindAll(x => x.TenTour.ToLower().Contains(keyword.ToLower().Trim()));
            return View("Index", ds);
        }

        public ActionResult TimKiemNangCao()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KQTimKiemNangCao(DateTime? tuNgay, DateTime? denNgay, string giaVe)
        {
            List<Tour> ds = db.DS_Tour;

            if (tuNgay.HasValue)
                ds = ds.FindAll(x => x.NgayDi >= tuNgay.Value);
            
            if (denNgay.HasValue)
                ds = ds.FindAll(x => x.NgayDi <= denNgay.Value);
            
            if (!string.IsNullOrEmpty(giaVe))
            {
                if (giaVe == "1") ds = ds.FindAll(x => x.GiaVe <= 1000000);
                else if (giaVe == "2") ds = ds.FindAll(x => x.GiaVe >= 1000000 && x.GiaVe <= 3000000);
                else if (giaVe == "3") ds = ds.FindAll(x => x.GiaVe >= 3000000 && x.GiaVe <= 5000000);
                else if (giaVe == "4") ds = ds.FindAll(x => x.GiaVe > 5000000);
            }

            return View("Index", ds);
        }

        public ActionResult ChiTiet(int id)
        {
            Tour tour = db.DS_Tour.Find(x => x.MaTour == id);
            
            // Dịch vụ đi kèm
            List<ChiTietTour> dsChiTiet = db.DS_ChiTietTour.FindAll(x => x.MaTour != null && x.MaTour.MaTour == id);
            List<DichVu> dichVu = new List<DichVu>();
            foreach (ChiTietTour ct in dsChiTiet)
            {
                if (ct.MaDV != null) dichVu.Add(ct.MaDV);
            }
            ViewBag.DichVu = dichVu;

            return View(tour);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string tenKH, string matKhau)
        {
            KhachHang kh = db.DS_KhachHang.Find(x => x.TenKH == tenKH && x.MatKhau == matKhau);
            if (kh != null)
            {
                Session["KhachHang"] = kh;
                return RedirectToAction("Index");
            }
            ViewBag.Error = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View();
        }
        
        public ActionResult Logout()
        {
            Session.Remove("KhachHang");
            return RedirectToAction("Index");
        }
    }
}
