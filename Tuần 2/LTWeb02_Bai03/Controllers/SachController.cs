using LTWeb02_Bai03.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWeb02_Bai03.Controllers
{
    public class SachController : Controller
    {
        public  List<LoaiSach> DS_Loai;
        public List<Sach> DS_Sach;
        public SachController()
        {
            DS_Loai = new List<LoaiSach>
            {
                new LoaiSach(1, "Sách giáo khoa"),
                new LoaiSach(2, "Sách từ điển"),
                new LoaiSach(3, "Truyện đại học"),
                new LoaiSach(4, "Truyện tranh")
            };

             DS_Sach = new List<Sach>
            {
                new Sach(1, "Toán 10 Nâng cao", 15000, "h1.png", DS_Loai[0]),
                new Sach(2, "Ngữ Văn 11", 2100, "h2.png", DS_Loai[0]),
                new Sach(3, "Từ điển 1000 từ", 56000, "h3.png", DS_Loai[1]),
                new Sach(4, "Anh - Việt 500 từ", 47000, "h4.png", DS_Loai[1]),
                new Sach(5, "Anh - Anh", 120900, "h5.png", DS_Loai[1]),
                new Sach(11, "Cơ sở dữ liệu", 34000, "h11.png", DS_Loai[2]),
                new Sach(14, "Doreamon", 45000, "h14.png", DS_Loai[3])
            };

        }

        // GET: Sach
        public ActionResult Index(int id = -1)
        {
            ViewBag.LoaiSach = DS_Loai;
            List<Sach> DS_Loc = new List<Sach>();
            if (id == -1)
                DS_Loc = DS_Sach;
            else 
                DS_Loc = DS_Sach.Where(X => X.Loai.MaLoai == id).ToList();
            return View(DS_Loc);
        }
    }
}